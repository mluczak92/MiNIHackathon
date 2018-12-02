using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEnemy : MonoBehaviour
{
    string choinaName = "ChoinaPre(Clone)";
    string bombaName = "BombaPre(Clone)";
    GameObject choina;
    public float speed = 0.005f;

    void Start()
    {
        transform.LookAt(choina.transform);
    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("cel");
        GameObject closestEnemy = choina;
        var distance = Mathf.Infinity;
        var playerPos = transform.position;

        foreach (var enemy in enemies)
        {
            var diff = enemy.transform.position - playerPos;
            var currDistance = diff.sqrMagnitude;
            Debug.Log("curr: " + currDistance + "distance: " + distance);

            if (currDistance < distance - 5)
            {
                closestEnemy = enemy;
                distance = currDistance;
            }
        }

        transform.LookAt(closestEnemy.transform);
        transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == choinaName)
            Destroy(gameObject);
        else if (col.gameObject.name == bombaName)
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            FindObjectOfType<GameController>().SpawnBombka();
        }
    }
}
