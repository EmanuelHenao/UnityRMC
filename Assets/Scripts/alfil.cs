using UnityEngine;
using System.Collections;

//hereda de la clase abstracta
public class alfil : pieza {

	public override bool[,] movimientoPosible(){
	
		bool[,] r = new bool[8, 8];

		pieza c;
		int i, j;

		//diagonal izquierda arriba
		i = ahoraX;
		j = ahoraY;

		while (true) {

			i--;
			j++;
			if (i < 0 || j >= 8)
				break;

			c = gestorTable.instancia.piezas [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (esBlanco != c.esBlanco)
					r [i, j] = true;
				
				break;
			}
		}

		//diagonal derecha arriba
		i = ahoraX;
		j = ahoraY;

		while (true) {

			i++;
			j++;
			if (i >= 8 || j >= 8)
				break;

			c = gestorTable.instancia.piezas [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (esBlanco != c.esBlanco)
					r [i, j] = true;

				break;
			}
		}

		//diagonal izquierda abajo
		i = ahoraX;
		j = ahoraY;

		while (true) {

			i--;
			j--;
			if (i < 0 || j < 0)
				break;

			c = gestorTable.instancia.piezas [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (esBlanco != c.esBlanco)
					r [i, j] = true;

				break;
			}
		}

		//diagonal derecha abajo
		i = ahoraX;
		j = ahoraY;

		while (true) {

			i++;
			j--;
			if (i >= 8 || j < 0)
				break;

			c = gestorTable.instancia.piezas [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (esBlanco != c.esBlanco)
					r [i, j] = true;

				break;
			}
		}

		return r;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
