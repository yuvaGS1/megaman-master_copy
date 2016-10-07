using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour {

	public string[] player;
	public string[] s_boardname = new string[10];
	public float[] s_boardscore = new float[10];
	public int j=0;
	public int l=0;
	public int m=0;


	public Text[] Names;
	public Text[] Score;
	public Playerinfo[] playerinfo = new Playerinfo[10];

	// Use this for initialization
	IEnumerator Start () { 
		yield return new WaitForSeconds (1);
		WWW playerdata = new WWW ("http://localhost/sk/highscoreretrieval.php");
		yield return playerdata;
		string playerdataString = playerdata.text;
		print (playerdataString);
		player = playerdataString.Split ("*".ToCharArray());
		print (player.Length/2);
		/*for (int i=0; i<player.Length-1; i++) 
		{
			print (player[i]);
		}*/
		for (int i=0; i<player.Length-1; i++) 
		{
			if(i%2 == 0)
			{
				print ("name :" +player[i]);
				s_boardname[j]=player[i];
				j = j+1;
			}
			else
			{
				print ("Score :" +player[i]);
				s_boardscore[l]=float.Parse(player[i]);
				l = l+1;
			}
		}
		for (int m=0; m<(player.Length/2); m++) 
		{
			print (s_boardname[m]);
			print (s_boardscore[m]);
		}
		//print(GetDataValue(player[0],"")); //after player[0], we can define the substring which can be used to start after that word ...

		for (int i=0; i<(playerinfo.Length); i++) 
		{
			playerinfo[i] = new Playerinfo();
			playerinfo[i].Name = s_boardname[i];
			playerinfo[i].score = s_boardscore[i];
			
		}

	}
	
	// Update is called once per frame
	public void Update () {
		for(int i=0;i<(player.Length/2);i++)
		{
			Names[i].text = sortArray()[i].Name;
			Score[i].text = sortArray()[i].score.ToString();
		}
	}

	
	public class Playerinfo
	{
		public string Name;
		public float score;
	}
	
	Playerinfo[] sortArray()
	{
		playerinfo = playerinfo.OrderByDescending (x => x.score).ToArray();
		return playerinfo;
	}

	/*string GetDataValue(string data,string index)
	{
		string value = data.Substring (data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}
*/
}
