using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Vector3 movement;
	private Animator animator;
	private Rigidbody rb;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake() {
		floorMask = LayerMask.GetMask ("Floor");
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Animate (h, v);
		Turning ();
	}

	void Move (float h, float v) {
		movement.Set (h, 0.0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}

	void Animate(float h, float v) {
		bool moving = h != 0f || v != 0f;
		animator.SetBool ("IsWalking", moving);
	}

	void Turning() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0.0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			rb.MoveRotation (newRotation);
		}
	}

}