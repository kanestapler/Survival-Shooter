using UnityEngine;
using System.Collections;

public class firstPersonCameraController : MonoBehaviour {

	public Transform targetPosition;
	public float smoothing = 3f;

	void Awake () {
	
	}

	void Update () {
		transform.rotation = targetPosition.rotation;
		transform.position = Vector3.Lerp (transform.position, targetPosition.position, smoothing);
	}
}
