using UnityEngine;
using System.Collections;

public class GameInitialisation : MonoBehaviour {
	void Start () {
	
	}

	void Update() {
		if(Input.GetKeyUp(KeyCode.E)) {
			Application.LoadLevel("House");
		}
	}
}
