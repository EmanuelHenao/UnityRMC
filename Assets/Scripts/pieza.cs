using UnityEngine;
using System.Collections;

public abstract class pieza : MonoBehaviour {

	public int ahoraX{ set; get;}
	public int ahoraY{ set; get;}
	//para definir que equipo es
	public bool esBlanco;

	public void asignarPosicion(int x , int y){
		ahoraX = x;
		ahoraY = y;

	}

	public virtual bool[,] movimientoPosible(){
		
		return new bool[8,8];
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
