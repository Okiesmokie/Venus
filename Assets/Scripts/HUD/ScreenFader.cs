using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {
	private bool isFading = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnAnimationComplete() {
		isFading = false;
	}

	public IEnumerator HUD_FadeOut() {
		GameControl.instance.PlayerCanMove = false;

		isFading = true;
		animator.SetTrigger("FadeOut");

		while(isFading)
			yield return null;

		GameControl.instance.PlayerCanMove = true;
	}

	public IEnumerator HUD_FadeIn() {
		GameControl.instance.PlayerCanMove = false;

		isFading = true;
		animator.SetTrigger("FadeIn");

		while(isFading)
			yield return null;

		GameControl.instance.PlayerCanMove = true;
	}
}
