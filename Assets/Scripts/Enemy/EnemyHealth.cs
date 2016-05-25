using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth;
	public AudioClip deathSound;
	public float sinkSpeed;
	public float destroyTime;
	public int scoreValue;

	private Animator anim;
	private int currentHealth;
	private bool isDead = false;
	private bool isSinking = false;
	private AudioSource audioSource;
	private Rigidbody rb;
	private ParticleSystem hitParticles;
	private CapsuleCollider capsuleCollider;

	void Awake(){
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
		hitParticles = GetComponentInChildren<ParticleSystem> ();
		capsuleCollider = GetComponent<CapsuleCollider> ();

		currentHealth = maxHealth;
	}

	void Update(){
		
		if (isSinking) {
			transform.Translate (Vector3.down * sinkSpeed * Time.deltaTime);
		}
	}

	public void Damage(int damage, Vector3 pointHit) {
		if (isDead)
			return;
		
		currentHealth -= damage;
		audioSource.Play();

		//Do particle system
		hitParticles.transform.position = pointHit;
		hitParticles.Play ();

		if (currentHealth <= 0) {
			Dead ();
		}
	}

	void Dead() {
		isDead = true;
		capsuleCollider.isTrigger = true;
		anim.SetTrigger("Dead");
		audioSource.clip = deathSound;
		audioSource.Play ();
	}

	public void StartSinking() {
		rb.isKinematic = true;
		GetComponent<NavMeshAgent> ().enabled = false;
		isSinking = true;
		Destroy (gameObject, destroyTime);
	}

	public bool IsDead() {
		return isDead;
	}
}
