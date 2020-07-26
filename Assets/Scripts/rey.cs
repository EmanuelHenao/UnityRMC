using UnityEngine;
using System.Collections;

//hereda de la clase abstracta
public class rey : pieza {

	public override bool[,] movimientoPosible(){
	
		bool[,] r = new bool[8,8];

		pieza c;
		int i, j;

		// diagonal arriba
		i = ahoraX - 1;
		j = ahoraY + 1;
		if (ahoraY != 7) {

			for (int k = 0; k < 3; k++) {

				if (i >= 0 || i < 8) {
				
					c = gestorTable.instancia.piezas [i, j];
					if (c == null)
						r [i, j] = true;
					else if (esBlanco != c.esBlanco)
						r [i, j] = true;
					
				}
				i++;
			}
		}

		// diagonal abajo
		i = ahoraX - 1;
		j = ahoraY - 1;
		if (ahoraY != 0) {

			for (int k = 0; k < 3; k++) {

				if (i >= 0 || i < 8) {

					c = gestorTable.instancia.piezas [i, j];
					if (c == null)
						r [i, j] = true;
					else if (esBlanco != c.esBlanco)
						r [i, j] = true;

				}
				i++;
			}
		}

		//medio izquierdo
		if(ahoraX != 0){

			c = gestorTable.instancia.piezas [ahoraX - 1, ahoraY];
			if (c == null)
				r [ahoraX - 1, ahoraY] = true;
			else if (esBlanco != c.esBlanco)
				r [ahoraX - 1, ahoraY] = true;
		}

		//medio derecho
		if(ahoraX != 7){

			c = gestorTable.instancia.piezas [ahoraX + 1, ahoraY];
			if (c == null)
				r [ahoraX + 1, ahoraY] = true;
			else if (esBlanco != c.esBlanco)
				r [ahoraX + 1, ahoraY] = true;
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
