using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEnemy : MonoBehaviour
{
    string choinaName = "ChoinaPre(Clone)";
    GameObject choina;
    public float speed = 0.005f;
    // Use this for initialization
    void Start()
    {
        choina = GameObject.Find(choinaName);
        transform.LookAt(choina.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, choina.transform.position, speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == choinaName)
            Destroy(gameObject);
    }
}
