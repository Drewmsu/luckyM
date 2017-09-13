using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grilla : MonoBehaviour {

	public LayerMask pasoNoPermitidoMask;
	public Vector2 grillaGeneralSize;
	public float radioNodo;
	//public Transform player; //Test 1
	Nodo[,] grilla;

	float diametroNodo;
	int grillaSizeX, grillaSizeY;

	void Start(){
		diametroNodo = radioNodo * 2;
		grillaSizeX = Mathf.RoundToInt(grillaGeneralSize.x / diametroNodo);
		grillaSizeY = Mathf.RoundToInt(grillaGeneralSize.y / diametroNodo);
		CrearGrilla ();
	}

	void CrearGrilla(){
		grilla = new Nodo[grillaSizeX, grillaSizeY];
		//position = centro del mapa
		Vector3 bottomLeft = transform.position - Vector3.right * grillaGeneralSize.x/2 - Vector3.forward * grillaGeneralSize.y/2; 
		
		for (int i = 0; i < grillaSizeX; i++){
			for (int j = 0; j < grillaSizeY; j++){
				Vector3 puntoMapa = bottomLeft + Vector3.right * (i * diametroNodo + radioNodo) + 
									Vector3.forward * (j * diametroNodo + radioNodo);
				bool pasoPermitido = !(Physics.CheckSphere(puntoMapa, radioNodo, pasoNoPermitidoMask));
				grilla[i, j] = new Nodo(pasoPermitido, puntoMapa);
			}
		}
	}

	public Nodo NodoEnMapa(Vector3 posGeneral){
		float porcentajeX = (posGeneral.x + grillaGeneralSize.x/2) / grillaGeneralSize.x;
		float porcentajeY =  (posGeneral.z + grillaGeneralSize.y/2) / grillaGeneralSize.y;

		porcentajeX = Mathf.Clamp01(porcentajeX);
		porcentajeY = Mathf.Clamp01(porcentajeY); 

		int x = Mathf.RoundToInt((grillaSizeX - 1) * porcentajeX);
		int y = Mathf.RoundToInt((grillaSizeY - 1) * porcentajeY);

		return grilla[x, y];
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(grillaGeneralSize.x, 1, grillaGeneralSize.y));

		if(grilla != null){
			//Nodo nodoPlayer = NodoEnMapa(player.position); //Test 1
			foreach (Nodo n in grilla){
				Gizmos.color = (n.pasoPermitido)?Color.white:Color.green;
				//if(nodoPlayer == n ) Gizmos.color = Color.red; //Test 1
				Gizmos.DrawCube(n.posGeneral, Vector3.one * (diametroNodo - 0.1f));
			}
		}
	}
}
