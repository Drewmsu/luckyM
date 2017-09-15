using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buscador : MonoBehaviour {

	public float velocidad = 6f;

	public static List<Nodo> camino;
	protected Animator _animator;

	public virtual void Start() {
        this._animator = GetComponent<Animator>();
    }
	void Update () {
		if (camino != null && camino.Count > 0) {
			Nodo siguientePaso = camino[0];
			Vector3 pos = siguientePaso.posGeneral;
			
			float step = this.velocidad * Time.deltaTime;
			this.transform.LookAt(pos);
			this.transform.position = Vector3.MoveTowards(transform.position, pos, step);
			this._animator.SetBool("Walking",true);
			camino.RemoveAt(0);
		}
	}
}
