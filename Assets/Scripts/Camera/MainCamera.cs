using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform target;
	public float scaleFactor = 4.0f;

	private Camera mainCamera;

	public static MainCamera instance;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(gameObject);
		} 
	}

	// Use this for initialization
	void Start() {
		mainCamera = GetComponent<Camera>();
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update() {
		mainCamera.orthographicSize = (Screen.height / 100.0f) / scaleFactor;

		if(target) {
			transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0.0f, 0.0f, -10.0f);
		}
	}

	public void MoveCameraInstant(Vector3 position) {
		transform.position = position;
	}

	public void ChangeCameraTarget(Transform newTarget) {
		target = newTarget;
	}
}
