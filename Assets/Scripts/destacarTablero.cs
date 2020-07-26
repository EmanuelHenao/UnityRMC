using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class destacarTablero : MonoBehaviour {

	public static destacarTablero instancia{ set; get;}

	public GameObject destacarPrefab;
	private List<GameObject> resaltador;

	// Use this for initialization
	private void Start () {
		instancia = this;
		resaltador = new List<GameObject> ();
	}

	private GameObject traerObjetoResaltador(){
		//busca el objeto si esta activo no 
		GameObject go = resaltador.Find (g => !g.activeSelf);

		if (go == null) {
			go = Instantiate (destacarPrefab);
			resaltador.Add (go);
		
		}

		return go;

	}

	public void resaltarMovimientosPermitidos(bool[,]movimientos){
	
		for (int i = 0; i < 8; i++) {
			
			for (int j = 0; j < 8; j++) {

				if (movimientos [i, j]) {

					GameObject go = traerObjetoResaltador ();
					go.SetActive (true);
					go.transform.position = new Vector3 (i+0.5f, 0, j+0.5f);
				}

			}
		}
	}

	public void ocultarResaltado(){
		foreach (GameObject go in resaltador)
			go.SetActive (false);
	
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
