using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	public int damagePerShot;
	public float rateOfFire;
	public float range;

	private float timer;
	private AudioSource gunFireSound;
	private Light gunLight;
	private LineRenderer bulletLine;
	private Ray shootRay;
	private RaycastHit shootHit;
	private int shootableMask;
	private ParticleSystem gunParticles;
	private float effectsDisplayTime = 0.2f;

	void Awake() {
		gunFireSound = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
		bulletLine = GetComponent<LineRenderer> ();
		gunParticles = GetComponent<ParticleSystem> ();
		shootableMask = LayerMask.GetMask ("Shootable");
	}

	void Update() {
		timer += Time.deltaTime;
		//Shoot
		if (Input.GetButton ("Fire1") && timer >= rateOfFire) {
			Shoot ();
		}
		//DisableShootEffects
		if (timer >= rateOfFire * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	void DisableEffects() {
		gunLight.enabled = false;
		bulletLine.enabled = false;
	}

	void Shoot() {
		//Reset timer
		timer = 0.0f;
		//Play audio
		gunFireSound.Play();
		//Turn on gun light
		gunLight.enabled = true;
		//Stop then start the gun particles
		gunParticles.Stop();
		gunParticles.Play ();
		//enable bulletLine
		bulletLine.enabled = true;
		//Set bullet starting point
		bulletLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.Damage (damagePerShot, shootHit.point);
			}
			bulletLine.SetPosition (1, shootHit.point);
		} else { // Doesn't hit anything under the shootableMask
			//Draw line the length of range
			bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * range); 
		}
	}

	public void TurnOffShooting() {
		DisableEffects ();
		this.enabled = false;
	}
}
