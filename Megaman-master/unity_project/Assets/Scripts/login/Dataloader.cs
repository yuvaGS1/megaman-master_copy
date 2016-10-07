using UnityEngine;
using System.Collections;

public class Dataloader : MonoBehaviour {

	public string[] player;

	// Use this for initialization
	IEnumerator Start () {
		WWW playerdata = new WWW ("http://localhost/sk/playerdata.php");
		yield return playerdata;
		print ("hai");
		string playerdataString = playerdata.text;
		print (playerdataString);
		player = playerdataString.Split (';');
		print(GetDataValue(player[0],"Score :")); //after player[0], we can define the substring which can be used to start after this word ...
	}

	string GetDataValue(string data,string index)
	{
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if(value.Contains("|"))
			value = value.Remove(value.IndexOf("|"));
		return value;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
