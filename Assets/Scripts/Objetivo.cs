using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour {

	public float velocidad;
	Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(velocidad*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, velocidad*Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
