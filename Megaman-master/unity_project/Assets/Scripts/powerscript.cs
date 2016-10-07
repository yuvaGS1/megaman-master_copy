using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class powerscript : MonoBehaviour {
	public Text theText;
	public GameObject power;
	public static int [] powers = {0,1,2,3,4,5,6,7,8,9};
	public static int count = 10;
	public int display_power;
	public GameObject button1;//assign the button object here
	public GameObject button2;//assign the button object here
	public GameObject button3;//assign the button object here
	public GameObject button4;//assign the button object here
	public GameObject button5;//assign the button object here
	public GameObject button6;//assign the button object here
	public GameObject button7;//assign the button object here
	public GameObject button8;//assign the button object here
	public GameObject button9;//assign the button object here
	public GameObject button0;//assign the button object here
	private bool isShowing;

	// Use this for initialization
	void Start () {
		Debug.Log("sample");
		count = 0;
	/*	theText.text = ToString();
		powers = theText.text;*/
	}
	// Update is called once per frame
	void Update () {
		checking ();
	} 

	void FixedUpdate () 
	{
		PowerPacks();
	//	powersholders ();
	}

	/*public void powersholders()
	{
		for(int i=0;i<powers.Length;i++){
			PlayerPrefs.SetInt("powers"+i,powers[i]);
		}
		for(int i=0;i<powers.Length;i++){
			print(PlayerPrefs.GetInt("powers"+i));
		}
	}*/

	public void buttonpress(int num)
	{
		theText.text = num.ToString();
		powers[count] = num;
		count = count + 1;
		switch(num) 
		{
		case 1:
			button1.GetComponent<Button>().interactable = false; 
			break;
		case 2:
			button2.GetComponent<Button>().interactable = false; 
			break;
		case 3:
			button3.GetComponent<Button>().interactable = false; 
			break;
		case 4:
			button4.GetComponent<Button>().interactable = false; 
			break;
		case 5:
			button5.GetComponent<Button>().interactable = false; 
			break;
		case 6:
			button6.GetComponent<Button>().interactable = false; 
			break;
		case 7:
			button7.GetComponent<Button>().interactable = false; 
			break;
		case 8:
			button8.GetComponent<Button>().interactable = false; 
			break;
		case 9:
			button9.GetComponent<Button>().interactable = false; 
			break;
		case 0:
			button0.GetComponent<Button>().interactable = false; 
			//button0.SetActive(false);
			break;
		}
	}

	public void LoadScene(int level)
	{
		StartCoroutine(gotoscene(level));
		
	}
	IEnumerator gotoscene(int level)
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel(level);
	}
	private void PowerPacks()
	{
		/*if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			theText.text = "0";
			powers[count] = 0;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			theText.text = "1";
			powers[count] = 1;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			theText.text = "2";
			powers[count] = 2;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			theText.text = "3";
			powers[count] = 3;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			theText.text = "4";
			powers[count] = 4;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			theText.text = "5";
			powers[count] = 5;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) 
		{
			theText.text = "6";
			powers[count] = 6;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			theText.text = "7";
			powers[count] = 7;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			theText.text = "8";
			powers[count] = 8;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			theText.text = "9";
			powers[count] = 9;
			count = count + 1;
			StartCoroutine(PowerLayers ());
		}*/
	}
	void checking()
	{
		if (Input.GetKeyDown (KeyCode.V)) 
		{
			print ("count"+count);
			for(int i=1 ; i <= count ; i++)
			{
				print (powers[i-1]);
			}
		}
	}
	IEnumerator PowerLayers()
	{
		yield return new WaitForSeconds(10);
		GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
	}
	
	


}
