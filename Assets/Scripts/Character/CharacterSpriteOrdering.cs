using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CharacterSpriteOrdering : MonoBehaviour {
	private Dictionary<string,int> spriteOrders = new Dictionary<string,int> {
		// GameObject	Path to spritesheet		Default path to spritesheet		Sorting Number
		{ "Body",		0 },
		{ "Hair",		4 },
		{ "Chest",		2 },
		{ "Shoulders",	3 },
		{ "Legs",		1 },
		{ "Feet",		2 }
	};

	public static System.Random randGen = new System.Random();
	private int randomSortValue;

	// Use this for initialization
	void Start () {

		randomSortValue = randGen.Next(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		try {
			var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

			foreach(var r in spriteRenderers) {
				foreach(KeyValuePair<string,int> entry in spriteOrders) {
					if(r.name.ToLowerInvariant() == entry.Key.ToLowerInvariant()) {
						r.sortingOrder = (int)(transform.position.y * -200.0f) + entry.Value + randomSortValue;
					}
				}
			}
		} catch(Exception e) {
			Debug.Log(e.ToString() + "\n" + e.Source);
		}
	}
}
