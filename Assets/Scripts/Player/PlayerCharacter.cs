using UnityEngine;
using System.Collections;

/*
 * PlayerSprite is a class with player-controlled movement
 */
public class PlayerCharacter : CharacterSprite {
	// Use this for initialization
	protected override void Start () {
		base.Start();

		DontDestroyOnLoad(gameObject);
		GameControl.instance.playerGameObject = gameObject;
	}

	protected override void OnAwake() {
		base.OnAwake();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
}
