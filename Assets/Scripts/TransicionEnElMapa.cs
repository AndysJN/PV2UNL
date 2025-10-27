using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class TransicionEnElMapa : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D MapBoundry;
    private CinemachineConfiner2D CMConfiner2D;
    [SerializeField] private Direction TravelDirection;
    [SerializeField] private Transform TeleportToPosition;
    [SerializeField] private float PushDistance = 2f;
    [SerializeField] private int FightMapIndex;
    
    enum Direction {Up, Down, Left, Right, Teleport, TeleportToMap}

    private void Awake()
    {
        CMConfiner2D = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CMConfiner2D.BoundingShape2D =  MapBoundry;
            UpdatePlayerPosition(other.GameObject());
        }
    }

    private void UpdatePlayerPosition(GameObject Player)
    {
        Vector3 NewPosition = Player.transform.position;

        switch (TravelDirection)
        {
            case Direction.Up:
                NewPosition.y += PushDistance;
                break;
            case Direction.Down:
                NewPosition.y -= PushDistance;
                break;
            case Direction.Left:
                NewPosition.x += PushDistance;
                break;
            case Direction.Right:
                NewPosition.y -= PushDistance;
                break;
            case Direction.Teleport:
                NewPosition = TeleportToPosition.position;
                break;
            case Direction.TeleportToMap:
                GameManager.Instance.GotoScene(FightMapIndex);
                break;
            default:
                break;
        }
        
        Player.transform.position = NewPosition;
    }
}
