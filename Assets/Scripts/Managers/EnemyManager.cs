using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float spawnTime;
	public GameObject enemy;
	public Transform[] spawnPosition;
	private PlayerHealth playerHealth;

    void Start () {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

	void Spawn() {
		if (!playerHealth.IsDead ()) {
			int randomIndex = Random.Range (0, spawnPosition.Length);
			Instantiate (enemy, spawnPosition [randomIndex].position, spawnPosition [randomIndex].rotation);
		}
	}
}
