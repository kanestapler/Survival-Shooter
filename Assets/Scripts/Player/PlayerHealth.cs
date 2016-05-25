using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
	public int maxHealth;
	public AudioClip dyingAudio;
	public Image damageImage;
	public Slider healthSlider;
	public float flashSpeed;
	public Color flashColor;

	private Animator anim;
	private PlayerMovement playerMovement;
	private AudioSource audioSource;
	private PlayerShooting playerShooting;
	private bool damaged;
	private bool isDead;
	private int currentHealth;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement> ();
		playerShooting = GetComponentInChildren<PlayerShooting> ();
		audioSource = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;
		damaged = false;
		isDead = false;
	}

	void Update() {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int damage) {
		if (!isDead) {
			Debug.Log ("Taking Damage");
			damaged = true;
			currentHealth -= damage;
			healthSlider.value = currentHealth;
			audioSource.Play ();
			if (currentHealth <= 0) {
				Death ();
			}
		}
	}

	public bool IsDead() {
		return isDead;
	}

	void Death() {
		isDead = true;
		playerMovement.enabled = false;
		//Play dying Audio
		audioSource.clip = dyingAudio;
		audioSource.Play ();
		//Flip anim flag saying playerDead
		anim.SetTrigger("Die");
		playerShooting.TurnOffShooting ();
	}
}
