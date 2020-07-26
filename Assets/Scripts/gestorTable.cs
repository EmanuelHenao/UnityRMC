using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gestorTable : MonoBehaviour {

	public static gestorTable instancia{ set; get;}
	private bool[,] movimientosPermitidos{ set; get;}

	//seleccionador de piezas
	public pieza[,] piezas{ set; get;}
	private pieza piezaSelccionada;

	//
	private const float azulejoSize=1.0f;
	private const float azulejoContra=0.5f;

	private int seleccionX = -1;
	private int seleccionY = -1;

	//lista donde se ponen los prefabs
	public List<GameObject> piezasPrefabs;
	private List<GameObject> activarPieza;

	//para hacer que resalte la pieza mientras se esta seleccionada
	private Material materialPrevio;
	public Material matSeleccionado;

	private Quaternion orientacion= Quaternion.Euler(0,0,0);

	public bool turnoBlancoEs=true;

	public Camera cam;
	public Camera cam2;

	public Text turno;
	public Text equipoGanador;

	public Canvas ganar;

	// Use this for initialization
	 private void Start () {
		
		instancia = this;
		llamarTodasPieza ();

		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		cam2 = GameObject.Find ("Main Camer").GetComponent<Camera> ();


		//llamarpieza(0,Vector3.zero);
		//llamarpieza (0,traerACentro(4,0));
	}
	
	// Update is called once per frame
	private void Update () {
		
		actualizarSeleccion ();
		DibujarTablero ();

		//comprueba si esta seleccionada la ficha y la mueve
		if (Input.GetMouseButtonDown (0)) {
			if (seleccionX >= 0 && seleccionY >= 0) {
				if (piezaSelccionada == null) {
					//seleccionar la pieza
					seleccionarPieza(seleccionX,seleccionY);
				} else {
					//mover la pieza
					moverPieza(seleccionX,seleccionY);
				}
			
			}
		}
	}

	private void seleccionarPieza(int x,int y){
		if (piezas[x,y]==null)
			return;

		if (piezas [x, y].esBlanco != turnoBlancoEs)
			return;

		bool tieneAlmenosUnMovimiento = false;
		movimientosPermitidos = piezas [x, y].movimientoPosible ();
		for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				if (movimientosPermitidos [i, j])
					tieneAlmenosUnMovimiento = true;

		piezaSelccionada = piezas [x, y];
		//cambiar de textura
		materialPrevio = piezaSelccionada.GetComponent<MeshRenderer> ().material;
		matSeleccionado.mainTexture = materialPrevio.mainTexture;
		piezaSelccionada.GetComponent<MeshRenderer> ().material = matSeleccionado;

		destacarTablero.instancia.resaltarMovimientosPermitidos (movimientosPermitidos);
	
	}

	private void moverPieza(int x, int y){
		//permite mover la pieza y resalta los cuadros de movimientos
		//solo deja mover  donde el "Resaltador" este
		if (movimientosPermitidos[x,y]) {

			pieza c = piezas [x, y];
			if (c != null && c.esBlanco != turnoBlancoEs) {
			
				//captura la pieza

				//si es el REY!!
				if(c.GetType()==typeof(rey)){

					//termina el juego
					gameOver();

					return;
				}

				activarPieza.Remove (c.gameObject);
				Destroy (c.gameObject);
			}
			if (piezaSelccionada.GetType () == typeof(peon)) {
			
				if (y == 7) {

					activarPieza.Remove (piezaSelccionada.gameObject);
					Destroy (piezaSelccionada.gameObject);
					llamarpieza (1, x, y);
					piezaSelccionada = piezas [x, y];
				}else if (y == 0) {

					activarPieza.Remove (piezaSelccionada.gameObject);
					Destroy (piezaSelccionada.gameObject);
					llamarpieza (7, x, y);
					piezaSelccionada = piezas [x, y];
				}
			}
	

			piezas [piezaSelccionada.ahoraX, piezaSelccionada.ahoraY] = null;
			piezaSelccionada.transform.position = traerACentro (x, y);
			piezaSelccionada.asignarPosicion (x,y);
			piezas [x, y] = piezaSelccionada;
			turnoBlancoEs = !turnoBlancoEs;

			//cambiar camara
			if (turnoBlancoEs == true) {
				turno.text="Equipo Blanco";
				cam.enabled = true;
				cam2.enabled = false;
			} else {
				turno.text="Equipo Negro";
				cam.enabled = false;
				cam2.enabled = true;
			}
		
		}

		piezaSelccionada.GetComponent<MeshRenderer> ().material = materialPrevio;
		destacarTablero.instancia.ocultarResaltado ();
		piezaSelccionada = null;
	}

	// muestra la ubicacion en el tablero de vectores 3
	private void actualizarSeleccion (){
		if (!Camera.main)
			return;
	
		RaycastHit toque;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out toque, 25.0f, LayerMask.GetMask ("Plano"))) {

		
			seleccionX = (int)toque.point.x;
			seleccionY = (int)toque.point.z;

		} else {
			seleccionX = -1;
			seleccionY = -1;

		}
	}

	//va a "crear" la pieza de la lista de elementos 
	private void llamarpieza(int index,int x, int y){
		
		GameObject go = Instantiate (piezasPrefabs [index], traerACentro(x,y), orientacion)as GameObject;
		go.transform.SetParent (transform);
		piezas [x, y] = go.GetComponent<pieza> ();
		piezas [x, y].asignarPosicion (x, y);
		activarPieza.Add (go);
	}

	private void llamarTodasPieza(){
		activarPieza = new List<GameObject> ();
		piezas= new pieza[8,8];

		//llamar las fichas blancas!!
		// primer numero es el index,
		//el segundo es la posicion en x y el ultimo es la posicon en y

		//rey
		llamarpieza (0,4,0);

		//reina
		llamarpieza (1,3,0);

		//torres
		llamarpieza (2,0,0);
		llamarpieza (2,7,0);

		//alfiles
		llamarpieza (3,2,0);
		llamarpieza (3,5,0);

		//caballos
		llamarpieza (4,1,0);
		llamarpieza (4,6,0);

		//peones
		for(int i=0;i<8;i++){
			llamarpieza (5,i,1);
		}
	
		//llamar las fichas Negras!!

		//rey
		llamarpieza (6,4,7);

		//reina
		llamarpieza (7,3,7);

		//torres
		llamarpieza (8,0,7);
		llamarpieza (8,7,7);

		//alfiles
		llamarpieza (9,2,7);
		llamarpieza (9,5,7);

		//caballos
		llamarpieza (10,1,7);
		llamarpieza (10,6,7);

		//peones
		for(int i=0;i<8;i++){
			llamarpieza (11,i,6);
		}

	}

	private Vector3  traerACentro(int x, int y){
		Vector3 origen = Vector3.zero;
		origen.x += (azulejoSize * x) + azulejoContra;
		origen.z += (azulejoSize * y) + azulejoContra;
		return origen;
	}

	private void DibujarTablero(){

		Vector3 lineaAncho = Vector3.right * 8;
		Vector3 lineaAlto = Vector3.forward * 8;

		//dibuja las linas de los vectores (vector en 3d)"el tablero"
		for(int i =0;i<=8;i++){

			Vector3 empieza = Vector3.forward * i;
			Debug.DrawLine (empieza, empieza + lineaAncho);

			for (int j = 0; j <=8 ; j++) {

				empieza = Vector3.right * j;
				Debug.DrawLine (empieza, empieza + lineaAlto);


			}
		}

		//dibuar la seleccion de los cuadros en el tablero(marcar la posicion)x
		if(seleccionX>=0&& seleccionY>=0){

			Debug.DrawLine (
				Vector3.forward * seleccionY + Vector3.right * seleccionX,
				Vector3.forward * (seleccionY + 1) + Vector3.right * (seleccionX + 1));

			Debug.DrawLine (
				Vector3.forward * (seleccionY + 1) + Vector3.right * seleccionX,
				Vector3.forward * seleccionY  + Vector3.right * (seleccionX + 1));
		}

	}

	private void gameOver(){
	
		ganar.gameObject.SetActive(true);

		if (turnoBlancoEs)
			equipoGanador.text = "equipo Blanco";
		else
			equipoGanador.text = "equipo Negro";

		foreach (GameObject go in activarPieza)
			Destroy (go);
		
		turnoBlancoEs = true;
		destacarTablero.instancia.ocultarResaltado ();
		llamarTodasPieza ();

	}

}

