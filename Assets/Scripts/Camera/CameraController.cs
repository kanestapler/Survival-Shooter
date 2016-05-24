using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float smoothing;
	public Transform follow;

	private Vector3 initialOffset;

	void Start () {
		initialOffset = transform.position - follow.position;
	}

	void FixedUpdate() {
		Vector3 newPosition = initialOffset + follow.position;
		transform.position = Vector3.Lerp (transform.position, newPosition, smoothing);
	}

}
