using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class bestscore : MonoBehaviour {
	public Text thetext;
	public string[] player;
	public string bscore;
	public Playerinfo[] playerinfo = new Playerinfo[1];

	// Use this for initialization
	IEnumerator Start () {
		PlayerPrefs.SetInt ("B_Score", 0);
		thetext = GetComponent<Text>();
		string S_User = PlayerPrefs.GetString ("username");
		yield return new WaitForSeconds (1);
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePOST", S_User);
		WWW www = new WWW ( "localhost/sk/viewmaxscore.php", form);
		yield return www;
		string playerdataString = www.text;
		print (playerdataString);
		player = playerdataString.Split ("*".ToCharArray());
		print (player.Length/2);
		print ("............................");
		for (int i=0; i<player.Length-1; i++) 
		{
			print ("score :" +player[i]);
			bscore = player[i];
		}
		print (bscore);
		PlayerPrefs.SetInt ("B_Score", int.Parse(bscore));

/*		for (int i=0; i<1; i++) 
		{
			playerinfo[i] = new Playerinfo();
			playerinfo[i].score = float.Parse(player[i]);
		}
*/		//	Debug.Log(PlayerPrefs.GetInt ("score"));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(PlayerPrefs.GetInt ("B_Score"));
		thetext.text = "" + PlayerPrefs.GetInt ("B_Score");
	/*	for (int i=0; i<player.Length-1; i++) 
		{
			print ("score :" +player[i]);
			bscore = player[i];
			thetext.text = playerinfo[i].score.ToString();
		}
		print (bscore);*/
		//for(int i=0;i<=playerinfo.Length;i++)
		//{
		//	print ("............................");
		//	print (player[0]);
			//thetext.text = playerinfo[i].score.ToString();
		//}
		//PlayerPrefs.SetInt ("P_Score", 0);
	}
	
	public class Playerinfo
	{
		public float score;
	}

}