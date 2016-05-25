using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

	private GameObject player;
	private Transform playerTransform;
	private NavMeshAgent nav;
	private EnemyHealth enemyHealth;
	private PlayerHealth playerHealth;

	void Awake() {
		nav = GetComponent<NavMeshAgent> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerTransform = player.transform;
	}

	void Update() {
		if (!enemyHealth.IsDead () && !playerHealth.IsDead ()) {
			nav.SetDestination (playerTransform.position);
		} else {
			nav.enabled = false;
		}
	}

}
