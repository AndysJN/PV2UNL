using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [Header("Pool")]
    public Projectile Prefab;
    public int PrewarmCount = 20;
    public bool ExpandIfEmpty = true;

    private readonly Queue<Projectile> AvailableQueue = new Queue<Projectile>();

    private void Awake()
    {
        if (Prefab == null)
        {
            Debug.LogError("[ProjectilePool] Prefab no asignado.", this);
            return;
        }

        for (int Index = 0; Index < PrewarmCount; Index++)
        {
            AvailableQueue.Enqueue(CreateInstance());
        }
    }

    private Projectile CreateInstance()
    {
        Projectile Proj = Instantiate(Prefab, transform);
        Proj.gameObject.SetActive(false);
        Proj.Pool = this;
        return Proj;
    }

    public Projectile Get()
    {
        Projectile Proj = (AvailableQueue.Count > 0)
            ? AvailableQueue.Dequeue()
            : (ExpandIfEmpty ? CreateInstance() : null);

        if (!Proj) return null;

        Proj.gameObject.SetActive(true);
        return Proj;
    }

    public void Return(Projectile Proj)
    {
        if (!Proj) return;

        Proj.gameObject.SetActive(false);
        Proj.transform.SetParent(transform, false);
        AvailableQueue.Enqueue(Proj);
    }
}

