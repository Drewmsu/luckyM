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
			Nodo nodoActual = listaAbierta[0];
			for(int i = 1; i < listaAbierta.Count; i++){
				if(listaAbierta[i].costoF < nodoActual.costoF || listaAbierta[i].costoF == nodoActual.costoF && listaAbierta[i].costoH < nodoActual.costoH) {
					nodoActual = listaAbierta[i];
				}
			}

			listaAbierta.Remove(nodoActual);
			listaCerrada.Add(nodoActual);

			if(nodoActual == nodoObjetivo) {
				return;
			}

			foreach	(Nodo abyacente in grilla.GetAbyacentes(nodoActual)) {
				if (!abyacente.pasoPermitido || listaCerrada.Contains(abyacente)) continue;

				int nuevoCostoMovAbyacente = nodoActual.costoG + GetDistancia(nodoActual, abyacente);
				if (nuevoCostoMovAbyacente < abyacente.costoG || !listaAbierta.Contains(abyacente)) {
					abyacente.costoG = nuevoCostoMovAbyacente;
					abyacente.costoH = GetDistancia(abyacente, nodoObjetivo);
				}
			}
		}
	}
	
	int GetDistancia (Nodo nodoA, Nodo nodoB) {
		int dX = Mathf.Abs(nodoA.grillaX - nodoB.grillaX);
		int dY = Mathf.Abs(nodoA.grillaY - nodoB.grillaY);

		if (dX > dY)
			return 14 * dY + 10 * (dX - dY);
		return 14 * dX + 10 * (dY - dX);
	}
}
