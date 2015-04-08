using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	public float scaleFactor = 4.0f;

	private Camera mainCamera;

	// Use this for initialization
	void Start() {
		mainCamera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update() {
		mainCamera.orthographicSize = (Screen.height / 100.0f) / scaleFactor;

		if(target) {
			transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0.0f, 0.0f, -10.0f);
		}
	}
}
