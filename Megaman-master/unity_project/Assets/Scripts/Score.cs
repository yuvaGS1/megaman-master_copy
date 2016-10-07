using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private Text thetext;

	// Use this for initialization
	void Start () {
		thetext = GetComponent<Text>();
	//	string S_User = PlayerPrefs.GetString ("username");

	//	Debug.Log(PlayerPrefs.GetInt ("score"));
	}

	// Update is called once per frame
	void Update () {
		//PlayerPrefs.SetInt ("P_Score", 0);
		thetext.text = "" + Mathf.Round (PlayerPrefs.GetInt ("P_Score"));

	}
}