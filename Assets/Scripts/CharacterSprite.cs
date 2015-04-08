using UnityEngine;
using System;
using System.Collections;

public class CharacterSprite : MonoBehaviour {
	private const string defaultBodySpritePath = "body/male/light";
	private const string defaultHairSpritePath = "hair/male/messy1/black";

	public string bodySpritePath = defaultBodySpritePath;
	public string hairSpritePath = defaultHairSpritePath;


	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void LateUpdate() {
		try {
			// Store paths in an array for easy iteration
			var spritePaths = new string[,] {
				{ "Body",	bodySpritePath,		defaultBodySpritePath },
				{ "Hair",	hairSpritePath,		defaultHairSpritePath }
			};

            // Random comment to test git

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
	
	// Update is called once per frame
	void Update () {
	}
}
