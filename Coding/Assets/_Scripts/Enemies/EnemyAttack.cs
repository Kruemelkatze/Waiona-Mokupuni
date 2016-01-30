using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float maximumDamage = 120f;                  // The maximum potential damage per shot.
	public float minimumDamage = 45f;                   // The minimum potential damage per shot.
	public float AttackSpeed = 1.5f;
	public AudioClip shotClip;                          // An audio clip to play when a shot happens.
	
	
	private SphereCollider col;                         // Reference to the sphere collider.
	private Transform player;                           // Reference to the player's transform.
	private bool attacking;                              // A bool to say whether or not the enemy is currently shooting.
	private EnemyAI enemyAI;
	private float cooldown = 0;

	void Awake ()
	{
		// Setting up the references.
		col = GetComponent<SphereCollider>();
		enemyAI = GetComponent<EnemyAI>();
	}
	
	
	void Update ()
	{
		if(enemyAI.CurrentEnemyState == EnemyAI.EnemyState.Attacking && cooldown <= 0) {
			Attack();
		}

		cooldown -= Time.deltaTime;

	}
	
	
	public void Attack ()
	{
		cooldown = AttackSpeed;

		// The player takes damage.
		Grid.EventHub.TriggerPlayerDamage(enemyAI.Target);
		
		//AudioSource.PlayClipAtPoint(shotClip, laserShotLight.transform.position);
	}

}