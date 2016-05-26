using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public float restartDelay;

	private Animator anim;
	private float restartTimer = 0;
	private PlayerHealth playerHealth;

    void Awake() {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		anim = GameObject.FindGameObjectWithTag ("HUDCanvas").GetComponent<Animator> ();
    }


    void Update() {
		if (playerHealth.IsDead ()) {
			anim.SetTrigger ("GameOver");
			restartTimer += Time.deltaTime;
			if (restartTimer > restartDelay) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
    }
}
