using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo {

	public Vector3 posGeneral;
	public bool pasoPermitido;
	public int grillaX;
	public int grillaY;

	public int costoG;

	//En este caso se usara Manhatan
	public int costoH; 

	public Nodo(bool _pasoPermitido, Vector3 _posGeneral, int _grillaX, int _grillaY) {
		pasoPermitido = _pasoPermitido;
		posGeneral = _posGeneral;
		grillaX = _grillaX;
		grillaY = _grillaY;
	}

	public int costoF {
		get{ return costoG + costoH; }
	}
}
