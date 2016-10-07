using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class gameovermanager : MonoBehaviour {

	public int p_score;

	string UpdateUserURL = "localhost/sk/updatescore.php";
	string UpdateUserScoreURL = "localhost/sk/highscoreinsertion.php";

	void Start()
	{
		p_score = PlayerPrefs.GetInt ("P_Score");
		string S_User = PlayerPrefs.GetString ("username");
		StartCoroutine(UpdateUser (S_User, p_score));
	}

	IEnumerator UpdateUser(string username , int score)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePOST", username);
		form.AddField ("scorePOST", score);
		WWW www = new WWW ( UpdateUserURL, form);
		WWW wwwupdate = new WWW ( UpdateUserScoreURL, form);
		yield return www;
		yield return wwwupdate;
		Debug.Log (www.text);
		Debug.Log (wwwupdate.text);
	}

	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
	}
	
	}
