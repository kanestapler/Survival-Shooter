using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

	private GameObject player;
	private Transform playerTransform;
	private NavMeshAgent nav;

	void Awake() {
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.transform;
	}

	void Update() {
		nav.SetDestination (playerTransform.position);
	}

}
