using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour {
	Grilla grilla;

	void Awake(){
		grilla = GetComponent<Grilla>();
	}

	void EncontrarCamino(Vector3 posInicial, Vector3 posObjetivo){
		Nodo nodoInicio = grilla.NodoEnMapa(posInicial);
		Nodo nodoObjetivo = grilla.NodoEnMapa(posObjetivo);

		List<Nodo> listaAbierta = new List<Nodo>();
		List<Nodo> listaCerrada = new List<Nodo>();

		listaAbierta.Add(nodoInicio);

		while(listaAbierta.Count > 0){
			
		}
	}
	
}
