using UnityEngine;
using System.Collections;

public class WarpObject : MonoBehaviour {
	public string levelName;
	public float warpX;
	public float warpY;
	public int directionX;
	public int directionY;

	IEnumerator OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player") {
			var screenFader = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<ScreenFader>();

			if(screenFader) {
				yield return StartCoroutine(screenFader.HUD_FadeOut());
			} else {
				Debug.LogError("Couldn't find screenfader");
			}

			var newPosition = new Vector3(warpX, warpY, 0.0f);

			collider.gameObject.transform.position = newPosition;
			MainCamera.instance.MoveCameraInstant(newPosition);

			foreach(var animator in collider.gameObject.GetComponentsInChildren<Animator>()) {
				animator.SetFloat("DirectionX", directionX);
				animator.SetFloat("DirectionY", directionY);
			}

			if(levelName != Application.loadedLevelName && levelName != string.Empty) {
				Application.LoadLevel(levelName);
			}

			if(screenFader) {
				yield return StartCoroutine(screenFader.HUD_FadeIn());
			}
		}
	}
}
