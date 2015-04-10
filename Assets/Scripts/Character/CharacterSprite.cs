using UnityEngine;
using System;
using System.Collections;

public class CharacterSprite : MonoBehaviour {
	protected const string defaultBodySpritePath = "body/male/light";
	protected const string defaultHairSpritePath = "hair/male/messy1/black";
	protected const string defaultChestSpritePath = "torso/leather/chest_male";
	protected const string defaultShouldersSpritePath = "torso/leather/shoulders_male";
	protected const string defaultLegsSpritePath = "legs/pants/male/white_pants_male";
	protected const string defaultFeetSpritePath = "feet/shoes/male/brown_shoes_male";

	public string bodySpritePath = defaultBodySpritePath;
	public string hairSpritePath = defaultHairSpritePath;
	public string chestSpritePath = defaultChestSpritePath;
	public string shouldersSpritePath = defaultShouldersSpritePath;
	public string legsSpritePath = defaultLegsSpritePath;
	public string feetSpritePath = defaultFeetSpritePath;

	protected SpriteRenderer spriteRenderer;
	protected Rigidbody2D rigidBody;
	protected Animator[] animators;

	public enum Directions {
		LEFT = -1, DOWN = -1,
		RIGHT = 1, UP = 1
	}

	// Use this for initialization
	protected virtual void LateUpdate() {
		try {
			// Store paths in an array for easy iteration
			string[,] spritePaths = new string[,] {
				// GameObject	Path to spritesheet		Default path to spritesheet		Sorting Number
				{ "Body",		bodySpritePath,			defaultBodySpritePath },
				{ "Hair",		hairSpritePath,			defaultHairSpritePath },
				{ "Chest",		chestSpritePath,		defaultChestSpritePath },
				{ "Shoulders",	shouldersSpritePath,	defaultShouldersSpritePath },
				{ "Legs",		legsSpritePath,			defaultLegsSpritePath },
				{ "Feet",		feetSpritePath,			defaultFeetSpritePath }
			};

			var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

			foreach(var renderer in spriteRenderers) {
				for(int i = 0; i < spritePaths.GetLength(0); ++i) {
					if(renderer.name.ToLowerInvariant() == spritePaths[i,0].ToLowerInvariant()) {
						//var atlas = Resources.Load(spritePath, typeof(Texture2D)) as Texture2D;
						var atlas = Resources.Load(spritePaths[i,1], typeof(Texture2D)) as Texture2D;

						if(!atlas) {
							Debug.Log("Unable to find sprite: " + spritePaths[i,1]);

							atlas = Resources.Load(spritePaths[i,2], typeof(Texture2D)) as Texture2D;
						}

						//renderer = GetComponent<SpriteRenderer>();

						renderer.sprite = Sprite.Create(atlas, renderer.sprite.rect, new Vector2(0.5f, 0.5f));

						renderer.sprite.name = renderer.name + "_sprite";
						renderer.material.mainTexture = atlas as Texture;
						renderer.material.shader = Shader.Find("Sprites/Default");
					}
				}
			}
		} catch (Exception e) {
			Debug.Log(e.ToString() + "\n" + e.Source);
		}
	}

	protected virtual void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		animators = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	}

	protected virtual void OnAwake() {
	}
}
