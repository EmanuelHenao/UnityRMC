using UnityEngine;
using System.Collections;

//hereda de la clase abstracta
public class peon : pieza {

	public override bool[,] movimientoPosible(){

		bool[,] r = new bool[8, 8];

		pieza c, c2;

		//movimientos si  son  blancas!!
		if (esBlanco) {

			//mueve diagonal izaquierda
			if(ahoraX != 0 && ahoraY != 7){
				c = gestorTable.instancia.piezas [ahoraX - 1, ahoraY + 1];

				if (c != null && !c.esBlanco)
					r [ahoraX - 1, ahoraY + 1] = true;
			}

			//mueve diagonal derecha
			if(ahoraX != 7 && ahoraY != 7){
				c = gestorTable.instancia.piezas [ahoraX + 1, ahoraY + 1];

				if (c != null && !c.esBlanco)
					r [ahoraX + 1, ahoraY + 1] = true;
			}

			//mueve
			if(ahoraY != 7){

				c = gestorTable.instancia.piezas [ahoraX, ahoraY + 1];

				if (c == null)
					r [ahoraX, ahoraY + 1] = true;
			}

			//primer movimiento
			if(ahoraY==1){

				c = gestorTable.instancia.piezas [ahoraX, ahoraY + 1];
				c2 = gestorTable.instancia.piezas [ahoraX, ahoraY + 2];

				if (c == null && c2 == null)
					r [ahoraX, ahoraY + 2] = true;

			}

		} else {
			//movimientos si son negras!!

			//mueve diagonal izaquierda
			if(ahoraX != 0 && ahoraY != 0){
				c = gestorTable.instancia.piezas [ahoraX - 1, ahoraY - 1];

				if (c != null && c.esBlanco)
					r [ahoraX - 1, ahoraY - 1] = true;
			}

			//mueve diagonal derecha
			if(ahoraX != 7 && ahoraY != 0){
				c = gestorTable.instancia.piezas [ahoraX + 1, ahoraY - 1];

				if (c != null && c.esBlanco)
					r [ahoraX + 1, ahoraY - 1] = true;
			}

			//mueve
			if(ahoraY != 0){

				c = gestorTable.instancia.piezas [ahoraX, ahoraY - 1];

				if (c == null)
					r [ahoraX, ahoraY- 1] = true;
			}

			//primer movimiento
			if(ahoraY==6){

				c = gestorTable.instancia.piezas [ahoraX, ahoraY - 1];
				c2 = gestorTable.instancia.piezas [ahoraX, ahoraY - 2];

				if (c == null && c2 == null)
					r [ahoraX, ahoraY - 2] = true;

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
