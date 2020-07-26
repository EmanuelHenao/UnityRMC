using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class funn : MonoBehaviour {

	//public GameObject imagencarga;
	public Slider barra;

	private AsyncOperation asyn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void btnSalir(){
		Application.Quit ();

	}

	public void btnAce(){
	
		SceneManager.LoadScene ("table");	
	}
	 
	public void  barraCarga(int nivel){
	
		//imagencarga.SetActive (true);
		StartCoroutine (LoadSlider (nivel));

	}
	IEnumerator LoadSlider(int nivel){
		asyn = SceneManager.LoadSceneAsync (nivel);

		while (!asyn.isDone) {
			barra.value = asyn.progress;

			yield return null;
			//Debug.Log ("carga completa");
		}
	}
}
