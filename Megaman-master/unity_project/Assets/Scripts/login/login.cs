using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class login : MonoBehaviour {

	//public string inputUserName;
	//public string inputPassword;
	public Text username;
	public Text password;

	string LoginURL = "localhost/SK/login.php";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void userlogin()
	{
		print ("buttonpressed");
		StartCoroutine(LoginToDB (username.text, password.text));
		//	StartCoroutine(LoginToDB (inputUserName, inputPassword));
	}

	IEnumerator LoginToDB(string username, string password)
	{

		WWWForm form = new WWWForm ();
		form.AddField ("usernamePOST",username);
		form.AddField ("passwordPOST",password);
		WWW www = new WWW(LoginURL,form);
		yield return www;
		string wwwString = www.text;
		print (wwwString);
		//Debug.Log (www.text);
		if (wwwString == "login successfully") 
		{
			PlayerPrefs.SetString("username",username);
			string S_Username = PlayerPrefs.GetString ("username");
			print(S_Username);
			StartCoroutine (gotonextlevel (1));
		}
		else if (wwwString == "incorrect password") 
		{
			StartCoroutine (gotonextlevel (0));
		}
		else if (wwwString == "user not found") 
		{
			StartCoroutine (gotonextlevel (0));
		}

	}
	IEnumerator gotonextlevel(int level)
	{
		yield return new WaitForSeconds (2);
		Application.LoadLevel(level);
	}
}
