using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{

	public int attackDamage;
	public float timeBetweenAttacks;

	private Animator anim;
	private GameObject player;
	private PlayerHealth playerHealth;
	private bool playerInRange;
	private float timeSinceLastAttack;


	void Awake() {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		timeSinceLastAttack = 0;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			playerInRange = true;
			Debug.Log ("I hit the player");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Update() {
		timeSinceLastAttack += Time.deltaTime;
		if (playerInRange && (timeSinceLastAttack > timeBetweenAttacks)) {
			Attack ();
		}
		if (playerHealth.IsDead ()) {
			anim.SetTrigger ("PlayerDead");
		}
	}

	void Attack() {
		if (!playerHealth.IsDead ()) {
			Debug.Log ("Attack!");
			timeSinceLastAttack = 0;
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
