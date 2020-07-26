using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class capture : MonoBehaviour {

	public InputField nick;
	public Text User;

	// Use this for initialization
	void Start () {
		string name;
		bool a =PlayerPrefs.HasKey ("Nick");
		if (a == true) {
			name = PlayerPrefs.GetString ("Nick");
			User.text = name;
		} else {
			User.text="no encontrado";

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void guardar(){
		string userNick;

		userNick = nick.text;
		PlayerPrefs.SetString ("Nick", userNick);
		Debug.Log (userNick);
	
	}

}
