using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 170f;           // Number of degrees, centred on forward, for the enemy see.
    public Vector3 LastSightedPlayerPosition;
    public float LastSightedPlayerTimeStamp;
    private Vector3 previousSighting;               // Where the player was sighted last frame.
    private bool seen;


    //private NavMeshAgent nav;                       // Reference to the NavMeshAgent component.
    private SphereCollider col;                     // reference to the sphere collider trigger component.
    //private Animator anim;                          // Reference to the Animator.
    //private GameObject[] players;
    private EnemyAI enemyAI;

    void Awake()
    {
        // Setting up the references.
        //nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        enemyAI = GetComponent<EnemyAI>();
        //Player = GameObject.Find("Lokahi");

    }


    void Update()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        CheckIfObjectIsVisible(Grid.Player);
        //if(other.gameObject.CompareTag(Tags.Projectile)) {

        //}

    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnTriggerStay(Collider other)
    {
        CheckIfObjectIsVisible(Grid.Player);

        //// If a player has entered the trigger sphere
        ////if(other.gameObject.CompareTag(Tags.Player))
        ////{
        ////	CheckIfObjectIsVisible(other.gameObject);
        ////}
    }




    void OnTriggerExit(Collider other)
    {
        // If the player leaves the trigger zone...
        //if(other.gameObject.CompareTag(Tags.Player)){
        //  Trigger event that notifies about a player leaving the range
        //	enemyAI.PlayerLeftSight(other.gameObject);
        //}
    }


    //float CalculatePathLength (Vector3 targetPosition)
    //{
    //    // Create a path and set it based on a target position.
    //    NavMeshPath path = new NavMeshPath();
    //    if(nav.enabled)
    //        nav.CalculatePath(targetPosition, path);

    //    // Create an array of points which is the length of the number of corners in the path + 2.
    //    Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

    //    // The first point is the enemy's position.
    //    allWayPoints[0] = transform.position;

    //    // The last point is the target position.
    //    allWayPoints[allWayPoints.Length - 1] = targetPosition;

    //    // The points inbetween are the corners of the path.
    //    for(int i = 0; i < path.corners.Length; i++)
    //    {
    //        allWayPoints[i + 1] = path.corners[i];
    //    }

    //    // Create a float to store the path length that is by default 0.
    //    float pathLength = 0;

    //    // Increment the path length by an amount equal to the distance between each waypoint and the next.
    //    for(int i = 0; i < allWayPoints.Length - 1; i++)
    //    {
    //        pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
    //    }

    //    return pathLength;
    //}



    private void CheckIfObjectIsVisible(GameObject go) {
		
		// Create a vector from the enemy to the player and store the angle between it and forward.
		Vector3 direction = go.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);
		
		// If the angle between forward and where the player is, is less than half the angle of view...
		if(angle < fieldOfViewAngle * 0.5f)
		{
            RaycastHit hit;
            // ... and if a raycast towards the player hits something...
            Debug.DrawRay(transform.position + transform.up, direction.normalized, Color.cyan, 2f );
            if(Physics.Raycast(transform.position, direction.normalized, out hit, col.radius))
            {

                // ... and if the raycast hits the player...
                if(hit.collider.gameObject.name.Equals(go.name))
                {
                    seen = true;
                    enemyAI.changeState(EnemyAI.EnemyState.Chasing);

                    // Trigger event that notifies a player entered the sight range
                    //enemyAI.PlayerEnteredSight(go);                    // Set the last global sighting is the players current position.
                    LastSightedPlayerPosition = go.transform.position;
                }
            }
		}
	}

}