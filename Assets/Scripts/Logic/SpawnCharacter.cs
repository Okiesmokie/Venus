using UnityEngine;
using System.Collections;

public class SpawnCharacter : MonoBehaviour {

	private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;

		if(elapsedTime >= 5.0f) {
			// Create a prefab character every 5 seconds
			var prefab = GameObject.Find("CharacterSprite");

			Vector3 pos = new Vector3(1.0f, 1.0f, 0.0f);
			var newObj = Instantiate(prefab, pos, Quaternion.identity) as GameObject;

			newObj.GetComponent<CharacterSpriteScript>().bodySpritePath = "body/male/light";

			elapsedTime = 0.0f;
		}
	}
}
