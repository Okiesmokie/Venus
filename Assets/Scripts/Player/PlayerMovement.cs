using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	protected Rigidbody2D rigidBody;
	protected Animator[] animators;

	// Use this for initialization
	protected virtual void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		animators = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(!GameControl.instance.PlayerCanMove) {
			movementVector = Vector2.zero;
		}

		if(movementVector != Vector2.zero) {
			// Player is moving
			foreach(var animator in animators) {
				animator.SetBool("isWalking", true);
				animator.SetFloat("DirectionX", movementVector.x);
				animator.SetFloat("DirectionY", movementVector.y);
			}

			rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime);

			// Update the player X and Y coordinates within the GameControl object
			GameControl.instance.PlayerX = rigidBody.position.x;
			GameControl.instance.PlayerY = rigidBody.position.y;
		} else {
			foreach(var animator in animators) {
				animator.SetBool("isWalking", false);
			}
		}
	}

	protected virtual void OnLevelWasLoaded(int level) {
		GameControl.instance.PlayerMap = Application.loadedLevelName;
		Debug.Log(Application.loadedLevelName);
	}
}
