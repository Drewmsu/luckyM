using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour {

	public float velocidad = 6.5f;
	Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) 
         	{
				if (Input.GetMouseButtonDown(0)) 
				{
					float step = this.velocidad * Time.deltaTime;

					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit))
					{
						newPosition = hit.point;
						transform.position = newPosition;
					}
				}
         	}
	}
}
