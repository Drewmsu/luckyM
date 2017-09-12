using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grilla : MonoBehaviour {

	public LayerMask pasoNoPermitidoMask;
	public Vector2 grillaSize;
	public float radioNodo;
	Nodo[,] grilla;
	
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(grillaSize.x,1,grillaSize.y));
	}
}