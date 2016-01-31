using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    //public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
    //public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
    //public float chaseWaitTime = 5f;                        // The amount of time to wait when the last sighting is reached.
    //public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
    public float AttackRange = 2f;
    public float MoveSpeed = 5f;
    //public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.
	public EnemyState CurrentEnemyState = EnemyState.Alert;
    public int LifePoints = 10;
    public float HitRate = 0.5f;

	private EnemySight enemySight;                          // Reference to the EnemySight script.
    //private NavMeshAgent nav;                               // Reference to the nav mesh agent.
    //private GameObject[] players;                               // Reference to the player's transform.
    //private float chaseTimer;                               // A timer for the chaseWaitTime.
    //private float patrolTimer;                              // A timer for the patrolWaitTime.
    //private int wayPointIndex;                              // A counter for the way point array.
    //private bool hasDestination = false;
    //private MeshRenderer mesh;

	public enum EnemyState {
		Alert, Chasing, Attacking, Calm
	}

    public void changeState(EnemyState state){
        CurrentEnemyState = state;
    }

	void Awake ()
	{
		// Setting up the references.
		enemySight = GetComponent<EnemySight>();
        //nav = GetComponent<NavMeshAgent>(); 
        ////players = GameObject.FindGameObjectsWithTag(Tags.Player);
        //mesh = GetComponentInChildren<MeshRenderer>();
	}
	
	
	void Update ()
	{
        //Debug.Log(CurrentEnemyState);
        switch (CurrentEnemyState)
        {
               
            case EnemyState.Chasing:
                Chasing();
                break;
            case EnemyState.Attacking:
                Attack();
                break;
        }   
        //if(Target == null) {
        //    Patrouling();
        //} else {
        //    //if(IsTargetInRange() && Grid.Game.IsPlayerAlive(Target))
        //    //	Attack();
			
        ////	else if(Grid.Game.IsPlayerAlive(Target))
        //    //	Chasing();
        //}
	}
	
	
	void Attack ()
	{
        //nav.Stop();
        //mesh.material.color = Color.white;

		CurrentEnemyState = EnemyState.Chasing;
        Random.seed = (int)Time.time;
        if (Random.value <= HitRate)
        {
			Grid.EventHub.TriggerLifeChanged(-1);
        }

	}
	
	
	void Chasing ()
	{
                //mesh.material.color = Color.yellow;
		
        //// Create a vector from the enemy to the last sighting of the player.
        //Vector3 sightingDeltaPos = enemySight.LastSightedPlayerPosition - transform.position;

        transform.LookAt(Grid.Player.transform);

        if (Vector3.Distance(transform.position, Grid.Player.transform.position) > AttackRange)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            if (!IsInvoking("Attack"))
            {
            if (Vector3.Distance(transform.position,  Grid.Player.transform.position) <= AttackRange)
            {
                //changeState(EnemyState.Attacking);
                InvokeRepeating("Attack", 0.1f, 1f);
            }
        }
        }
	}
	
	
	void Patrouling ()
	{
		//mesh.material.color = Color.blue;
		
		CurrentEnemyState = EnemyState.Alert;
		
        //// Set an appropriate speed for the NavMeshAgent.
        //nav.speed = patrolSpeed;
		
        //// If near the next waypoint or there is no destination...
        //if(hasDestination || nav.remainingDistance < nav.stoppingDistance)
        //{
        //    // ... increment the timer.
        //    patrolTimer += Time.deltaTime;
			
        //    // If the timer exceeds the wait time...
        //    if(patrolTimer >= patrolWaitTime)
        //    {
        //        // ... increment the wayPointIndex.
        //        if(wayPointIndex == patrolWayPoints.Length - 1)
        //            wayPointIndex = 0;
        //        else
        //            wayPointIndex++;
				
        //        // Reset the timer.
        //        patrolTimer = 0;
        //    }
        //}
        //else
        //    // If not near a destination, reset the timer.
        //    patrolTimer = 0;
		
        //// Set the destination to the patrolWayPoint.
        //nav.destination = patrolWayPoints[wayPointIndex].position;
	}


	private bool IsTargetInRange() {
		return AttackRange > Vector3.Distance(Grid.Player.transform.position, transform.position);
	}

    //public void PlayerLeftSight(GameObject player) {
    //    Target = null;
    //}


}