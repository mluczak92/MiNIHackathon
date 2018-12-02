using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEnemy : MonoBehaviour {
    GameObject choina;
    public float speed = 0.01f;
	// Use this for initialization
	void Start () {
        choina = GameObject.Find("ChoinaPre(Clone)");
        transform.LookAt(choina.transform);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, choina.transform.position, speed);
    }
}
