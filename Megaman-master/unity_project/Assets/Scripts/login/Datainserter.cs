using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Datainserter : MonoBehaviour {

	public string inputUserName;
	public string inputEmail;
	public string inputPassword;
	public Text username;
	public Text email;
	public Text password;


	string CreateUserURL = "localhost/sk/insertuser.php";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			print ("keypressed");
			StartCoroutine(CreateUser (username.text, email.text, password.text));
			//StartCoroutine(CreateUser (inputUserName, inputEmail, inputPassword));
		}
	}

	IEnumerator CreateUser(string username, string email, string password)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePOST", username);
		form.AddField ("emailPOST", email);
		form.AddField ("passwordPOST", password);
		WWW www = new WWW (CreateUserURL, form);
		yield return www;
		Debug.Log (www.text);

	}

}
