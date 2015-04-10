using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour {
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
