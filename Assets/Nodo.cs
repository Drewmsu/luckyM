using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo {

	public Vector3 posGeneral;
	public bool pasoPermitido;

	public int costoG;

	//En este caso se usara Manhatan
	public int costoH; 

	public Nodo(bool _pasoPermitido, Vector3 _posGeneral){
		pasoPermitido = _pasoPermitido;
		posGeneral = _posGeneral;
	}

	public int costoF {
		get{ return costoG + costoH; }
	}
}
