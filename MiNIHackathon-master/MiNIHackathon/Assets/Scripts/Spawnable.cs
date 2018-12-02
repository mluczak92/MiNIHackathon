using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionIndicator))]
public class Spawnable : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(GameObject Cursor)
    {
        DirectionIndicator directionIndicator = gameObject.GetComponent<DirectionIndicator>();
        directionIndicator.Cursor = Cursor;
    }
}
