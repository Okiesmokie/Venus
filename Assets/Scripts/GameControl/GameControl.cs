using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public partial class GameControl : MonoBehaviour {
	#region Singleton Code
	public static GameControl instance;
	#endregion

	private Dictionary<string, object> gameFlags = new Dictionary<string,object>();

	public GameObject playerGameObject;

	#region Player Attributes Helpers
	public int PlayerHP {
		get {
			return GetFlag<int>("PlayerHP");
		}

		set {
			SetFlag<int>("PlayerHP", value);
		}
	}

	public int PlayerMaxHP {
		get {
			return GetFlag<int>("PlayerMaxHP");
		}

		set {
			SetFlag<int>("PlayerMaxHP", value);
		}
	}

	public string PlayerMap {
		get {
			return GetFlag<string>("PlayerMap");
		}

		set {
			SetFlag<string>("PlayerMap", value);
		}
	}

	public float PlayerX {
		get {
			return GetFlag<float>("PlayerX");
		}

		set {
			SetFlag<float>("PlayerX", value);
		}
	}

	public float PlayerY {
		get {
			return GetFlag<float>("PlayerY");
		}

		set {
			SetFlag<float>("PlayerY", value);
		}
	}

	public bool PlayerCanMove {
		get {
			return GetFlag<bool>("PlayerCanMove", true);
		}

		set {
			SetFlag<bool>("PlayerCanMove", value);
		}
	}
	#endregion

	void Awake() {
		#region Singleton Code
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(gameObject);
		}
		#endregion

		saveFileName = Application.persistentDataPath + "/gamedata_debug.dat";

		//SaveGame();
		LoadGame();
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 200, 30), string.Format("HP: {0}/{1}", PlayerHP, PlayerMaxHP));
		GUI.Label(new Rect(10, 30, 200, 30), string.Format("Map: {0}", PlayerMap));
		GUI.Label(new Rect(10, 50, 200, 30), string.Format("Position: ({0},{1})", PlayerX, PlayerY));
	}

	#region Flag Getting/Setting
	public T GetFlag<T>(string key, T defaultValue = default(T)) {
		T flag;

		try {
			flag = (T)gameFlags[key];
		} catch(KeyNotFoundException) {
			flag = defaultValue;
		}

		return flag;
	}

	public void SetFlag<T>(string key, T value) {
		gameFlags[key] = (object)value;
	}
	#endregion

	#region Saving and Loading Code
	private string saveFileName;

	public void SaveGame() {
		try {
			using(var fs = new FileStream(saveFileName, FileMode.Create, FileAccess.Write)) {
				var bf = new BinaryFormatter();
				bf.Serialize(fs, gameFlags);

				fs.Close();
			}
		} catch(Exception e) {
			Debug.Log(e.ToString());
		}
	}

	public void LoadGame() {
		if(File.Exists(saveFileName)) {
			try {
				using(var fs = new FileStream(saveFileName, FileMode.Open, FileAccess.Read)) {
					gameFlags.Clear();

					var bf = new BinaryFormatter();
					gameFlags = (Dictionary<string, object>)bf.Deserialize(fs);
				}

				Debug.Log(string.Format("testFlag: {0}", GetFlag<int>("testFlag")));
				Debug.Log(string.Format("secondTestFlag: {0}", GetFlag<string>("secondTestFlag")));
			} catch(Exception e) {
				Debug.Log(e.ToString());
			}
		} else {
			// No save file exists, start a new game
			LoadDefaults();
		}
	}

	private void LoadDefaults() {
		// Default values for a new game
		PlayerHP = 100;
		PlayerMaxHP = 100;
		PlayerMap = "Start";
		PlayerX = 100;
		PlayerY = 100;
	}
	#endregion
}
