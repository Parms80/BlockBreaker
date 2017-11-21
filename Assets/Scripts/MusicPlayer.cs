using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer musicPlayerInstance = null;

	void Awake()
	{
		if (musicPlayerInstance != null) {
			Destroy (gameObject);
			Debug.Log ("Duplicate music player self-destructing");
		} else {
			//			Debug.Log ("Creating new music player");
			musicPlayerInstance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	void Start () {
		Debug.Log ("MusicPlayer Start " + GetInstanceID ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
