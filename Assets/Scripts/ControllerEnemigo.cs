using UnityEngine;

public class ControllerEnemigo : MonoBehaviour
{
    public Transform[] Waypoints;
    public float Speed = 10f;
    public int DestinationWaypoint = 0;

    void Update()
    {
        if (DestinationWaypoint == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[DestinationWaypoint].position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Waypoints[DestinationWaypoint].position) <= .5f)
            {
                DestinationWaypoint = 1;
            }
        }
        
        if (DestinationWaypoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[DestinationWaypoint].position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Waypoints[DestinationWaypoint].position) <= .5f)
            {
                DestinationWaypoint = 0;
            }
        }
    }
}
