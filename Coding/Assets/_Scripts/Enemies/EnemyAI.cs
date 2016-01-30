using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
	public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
	public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
	public float chaseWaitTime = 5f;                        // The amount of time to wait when the last sighting is reached.
	public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
	public float AttackRange = 2f;
	public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.
	public EnemyState CurrentEnemyState = EnemyState.Patrouling;
	

	private EnemySight enemySight;                          // Reference to the EnemySight script.
	private NavMeshAgent nav;                               // Reference to the nav mesh agent.
	private GameObject[] players;                               // Reference to the player's transform.
	private float chaseTimer;                               // A timer for the chaseWaitTime.
	private float patrolTimer;                              // A timer for the patrolWaitTime.
	private int wayPointIndex;                              // A counter for the way point array.
	public GameObject Target;
	private bool hasDestination = false;
	private MeshRenderer mesh;

	public enum EnemyState {
		Patrouling, Chasing, Attacking
	}

	void Awake ()
	{
		// Setting up the references.
		enemySight = GetComponent<EnemySight>();
		nav = GetComponent<NavMeshAgent>(); 
		players = GameObject.FindGameObjectsWithTag(Tags.Player);
		mesh = GetComponentInChildren<MeshRenderer>();
	}
	
	
	void Update ()
	{
		if(Target == null) {
			Patrouling();
		} else {
			if(IsTargetInRange() && Grid.Game.IsPlayerAlive(Target))
				Attack();
			
			else if(Grid.Game.IsPlayerAlive(Target))
				Chasing();
		}
	}
	
	
	void Attack ()
	{
		nav.Stop();
		mesh.material.color = Color.white;
		CurrentEnemyState = EnemyState.Attacking;
	}
	
	
	void Chasing ()
	{
		CurrentEnemyState = EnemyState.Chasing;
		mesh.material.color = Color.yellow;
		
		// Create a vector from the enemy to the last sighting of the player.
		Vector3 sightingDeltaPos = enemySight.LastSightedPlayerPosition - transform.position;

		transform.LookAt(Target.transform);

		// If the the last personal sighting of the player is not close...
		if(sightingDeltaPos.sqrMagnitude > 4f)
			// ... set the destination for the NavMeshAgent to the last personal sighting of the player.
			nav.destination = enemySight.LastSightedPlayerPosition;
		
		// Set the appropriate speed for the NavMeshAgent.
		nav.speed = chaseSpeed;
		
		// If near the last personal sighting...
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the timer.
			chaseTimer += Time.deltaTime;
			
			// If the timer exceeds the wait time...
			if(chaseTimer >= chaseWaitTime)
			{
				// ... reset last global sighting, the last personal sighting and the timer.
				chaseTimer = 0f;
			}
		}
		else
			// If not near the last sighting personal sighting of the player, reset the timer.
			chaseTimer = 0f;
	}
	
	
	void Patrouling ()
	{
		mesh.material.color = Color.blue;
		
		CurrentEnemyState = EnemyState.Patrouling;
		
		// Set an appropriate speed for the NavMeshAgent.
		nav.speed = patrolSpeed;
		
		// If near the next waypoint or there is no destination...
		if(hasDestination || nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the timer.
			patrolTimer += Time.deltaTime;
			
			// If the timer exceeds the wait time...
			if(patrolTimer >= patrolWaitTime)
			{
				// ... increment the wayPointIndex.
				if(wayPointIndex == patrolWayPoints.Length - 1)
					wayPointIndex = 0;
				else
					wayPointIndex++;
				
				// Reset the timer.
				patrolTimer = 0;
			}
		}
		else
			// If not near a destination, reset the timer.
			patrolTimer = 0;
		
		// Set the destination to the patrolWayPoint.
		nav.destination = patrolWayPoints[wayPointIndex].position;
	}


	private bool IsTargetInRange() {
		return AttackRange > Vector3.Distance(Target.transform.position, transform.position);
	}

	public void PlayerLeftSight(GameObject player) {
		Target = null;
	}

	public void PlayerEnteredSight(GameObject player) {
		if(Target == null) {
			Target = player;
		}
	}

}