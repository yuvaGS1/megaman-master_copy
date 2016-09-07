using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class powerscript : MonoBehaviour {
	public Text theText;
	public GameObject power;

	// Use this for initialization
	void Start () {
		Debug.Log("sample");
	}
	// Update is called once per frame
	void Update () {
	} 

	void FixedUpdate () 
	{
		PowerPacks();
	}

	public void buttonpress(int num)
	{
		theText.text = num.ToString();
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
		if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			theText.text = "0";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			theText.text = "1";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			theText.text = "2";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			theText.text = "3";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			theText.text = "4";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			theText.text = "5";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) 
		{
			theText.text = "6";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			theText.text = "7";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			theText.text = "8";
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			theText.text = "9";
			StartCoroutine(PowerLayers ());
		}
	}
	IEnumerator PowerLayers()
	{
		yield return new WaitForSeconds(10);
		GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
	}
	
	


}
