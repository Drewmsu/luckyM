using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grilla : MonoBehaviour {

	public LayerMask pasoNoPermitidoMask;
	public Vector2 grillaGeneralSize;
	public float radioNodo;

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
				grilla[i, j] = new Nodo(pasoPermitido, puntoMapa, i, j);
			}
		}
	}

	public List<Nodo> GetAbyacentes(Nodo nodo) {
		List<Nodo> abyacentes = new List<Nodo>();

		for (int i = -1; i <= 1; i++) {
			for (int j = -1; j <= 1; j++) {
				if (i == 0 && j == 0) continue;

			 	int verX = nodo.grillaX + i;
				int verY = nodo.grillaY + j;
				
				if (verX >= 0 && verX < grillaSizeX &&
					verY >= 0 && verY < grillaSizeY) { 
						abyacentes.Add(grilla[verX, verY]);
					}
			}
		}
		return abyacentes;
	}

	public Nodo NodoEnMapa(Vector3 posGeneral){
		float porcentajeX = (posGeneral.x + grillaGeneralSize.x/2) / grillaGeneralSize.x;
		float porcentajeY =  (posGeneral.z + grillaGeneralSize.y/2) / grillaGeneralSize.y;

		porcentajeX = Mathf.Clamp01(porcentajeX);
		porcentajeY = Mathf.Clamp01(porcentajeY); 

		int x = Mathf.RoundToInt((grillaSizeX - 1) * porcentajeX);
		int y = Mathf.RoundToInt((grillaSizeY - 1) * porcentajeY);

		return grilla[x, y];
		/*float porcentajeX = (posGeneral.x) / grillaGeneralSize.x;
  		float porcentajeY = (posGeneral.z) / grillaGeneralSize.y;
  		porcentajeX = Mathf.Clamp01(porcentajeX);
  		porcentajeY = Mathf.Clamp01(porcentajeY);

		int x = Mathf.RoundToInt((grillaSizeX - 1) * porcentajeX);
		int y = Mathf.RoundToInt((grillaSizeY - 1) * porcentajeY);

		return grilla[x,y];*/
	}

	public List<Nodo> camino; //Test 2
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(grillaGeneralSize.x, 1, grillaGeneralSize.y));

		if(grilla != null){

			foreach (Nodo n in grilla){
				Gizmos.color = (n.pasoPermitido)?Color.white:Color.green;
				if (camino != null) //Test 2
					if (camino.Contains(n)) //Test 2
						Gizmos.color = Color.black; //Test 2
				Gizmos.DrawCube(n.posGeneral, Vector3.one * (diametroNodo - 0.1f));
			}
		}
	}
}
