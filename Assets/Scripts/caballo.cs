using UnityEngine;
using System.Collections;

//hereda de la clase abstracta
public class caballo : pieza {

	public override bool[,] movimientoPosible(){

		bool[,]r=new bool[8,8];

		//"l" arriba izquierda
		movimientoCaballo(ahoraX - 1, ahoraY + 2,ref r);

		//"l" arriba Derecha
		movimientoCaballo(ahoraX + 1, ahoraY + 2,ref r);

		//"l" derecha arriba 
		movimientoCaballo(ahoraX + 2 , ahoraY + 1,ref r);

		//"l"  Derecha abajo
		movimientoCaballo(ahoraX + 2, ahoraY - 1,ref r);

		//"l" abajo izquierda
		movimientoCaballo(ahoraX - 1, ahoraY - 2,ref r);

		//"l" abajo Derecha
		movimientoCaballo(ahoraX + 1, ahoraY - 2,ref r);

		//"l" izquierda arriba 
		movimientoCaballo(ahoraX - 2 , ahoraY + 1,ref r);

		//"l"  izquierda abajo
		movimientoCaballo(ahoraX - 2, ahoraY - 1,ref r);

		return r;
	}

	public void movimientoCaballo(int x, int y,ref bool[,] r){
		pieza c;

		if (x >= 0 && x < 8 && y >= 0 && y < 8) {

			c = gestorTable.instancia.piezas [x, y];

			if (c == null)
				r [x, y] = true;
			else if (esBlanco != c.esBlanco)
				r [x, y] = true;
		}

	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
