using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCeiling : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
