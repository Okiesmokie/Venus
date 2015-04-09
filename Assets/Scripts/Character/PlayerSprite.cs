using UnityEngine;
using System.Collections;

/*
 * PlayerSprite is a class with player-controlled movement
 */
public class PlayerSprite : CharacterSprite {
	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

		var movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if(movementVector != Vector2.zero) {
			// Player is moving
			foreach(var animator in animators) {
				animator.SetBool("isWalking", true);
				animator.SetFloat("DirectionX", movementVector.x);
				animator.SetFloat("DirectionY", movementVector.y);
			}
		} else {
			foreach(var animator in animators) {
				animator.SetBool("isWalking", false);
			}
		}

		rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime);

		// Update the player X and Y coordinates within the GameControl object
		GameControl.instance.PlayerX = rigidBody.position.x;
		GameControl.instance.PlayerY = rigidBody.position.y;
	}
}
