using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour {


	public Text[] Names;
	public Text[] K;
	public Text[] D;
	public Text[] Score;
	public Playerinfo[] playerinfo = new Playerinfo[6];

	// Use this for initialization
	void Start () {
		for (int i=0; i<playerinfo.Length; i++) 
		{
			playerinfo[i] = new Playerinfo();
			playerinfo[i].Name = "Player" + i;
			playerinfo[i].k = Random.Range(0,30);
			playerinfo[i].d = Random.Range(0,30);
			playerinfo[i].score = (playerinfo[i].k / playerinfo[i].d) * 10;

		}
	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0;i<playerinfo.Length;i++)
		{
			Names[i].text = sortArray()[i].Name;
			K[i].text = sortArray()[i].k.ToString();
			D[i].text = sortArray()[i].d.ToString();
			Score[i].text = sortArray()[i].score.ToString();
		}

	}

	public class Playerinfo
	{
		public string Name;
		public float k;
		public float d;
		public float score;
	}

	Playerinfo[] sortArray()
	{
		playerinfo = playerinfo.OrderBy (x => x.score).ToArray();
		return playerinfo;
	}
}
