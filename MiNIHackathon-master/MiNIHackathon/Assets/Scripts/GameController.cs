using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

public class GameController : MonoBehaviour
{
    public GameObject Cursor;

    public Spawnable spawnObjectPrefab;
    public Spawnable enemyPrefab;
    public Spawnable bombkaPrefab;
    public int startDistance = 2;
    public int enemyRadius = 4;
    public int enemySeconds = 1;
    public int iloscBombek = 10;

    GameObject choinka;
    TapToPlace choinkaSc;

    private bool IsGravity = false;
    private bool wasTrue = false;
    private bool started = false;

    // Use this for initialization
    void Start()
    {
        if (!Cursor)
        {
            Debug.LogError("!Cursor");
        }
        if (!spawnObjectPrefab)
        {
            Debug.LogError("!spawnObjectPrefab");
        }

        //GravityOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (choinkaSc != null && !started)
        {
            if (choinkaSc.IsBeingPlaced)
                wasTrue = true;
            if (wasTrue && !choinkaSc.IsBeingPlaced)
            {
                started = true;
                SpawnBombki();
                SpawnNextEnemy();
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("GameController::StartGame");

        choinka = SpawnObject();
        choinkaSc = choinka.GetComponent<TapToPlace>();
        //SpawnBombki();
        //SpawnNextEnemy();
    }

    public GameObject SpawnObject()
    {
        return Spawn(spawnObjectPrefab, new Vector3(startDistance, 0, startDistance), Quaternion.identity);
    }

    private void SpawnBombki()
    {
        for (int i = 0; i < iloscBombek; i++)
        {
            SpawnBombka();
        }

    }

    public void SpawnBombka()
    {
        BoxCollider box = choinka.GetComponent<BoxCollider>();
        Vector3 choinkaPoss = choinka.transform.position;
        float from = -enemyRadius + startDistance;
        float to = enemyRadius + startDistance;
        GameObject bombka = Spawn(bombkaPrefab, new Vector3(Random.Range(from, to), Random.Range(choinkaPoss.y, box.size.y), Random.Range(from, to)), Quaternion.identity);
        Vector3 closest = box.ClosestPoint(bombka.transform.position);
        bombka.transform.position = closest;
    }

    private void SpawnNextEnemy()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(enemySeconds);
        float from = -enemyRadius + startDistance;
        float to = enemyRadius + startDistance;
        Spawn(enemyPrefab, new Vector3(Random.Range(from, to), 0, Random.Range(from, to)), Quaternion.identity);
        SpawnNextEnemy();
    }

    public GameObject Spawn(
    Spawnable spawnObjectPrefab,
    Vector3 position,
    Quaternion rotation)
    {
        Debug.Log("Spawner::Spawn");
        var spawnedObject = Instantiate(spawnObjectPrefab, position, rotation, null);
        SpawnInit(spawnedObject);
        return spawnedObject.MyGameObject;
    }

    private void SpawnInit(Spawnable spawnedObject)
    {
        spawnedObject.Init(Cursor);
        var rigidbody = spawnedObject.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.isKinematic = !IsGravity;
        }
    }

    public void ToggleGravity()
    {
        if (IsGravity)
        {
            GravityOff();
        }
        else
        {
            GravityOn();
        }
    }

    public void GravityOn()
    {
        IsGravity = true;

        Debug.Log("Spawner::GravityOn");

        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach (var foundObject in foundObjects)
        {
            foundObject.isKinematic = false;
        }
    }

    public void GravityOff()
    {
        IsGravity = false;

        Debug.Log("Spawner::GravityOff");

        var foundObjects = FindObjectsOfType<Rigidbody>();
        foreach (var foundObject in foundObjects)
        {
            foundObject.isKinematic = true;
        }
    }
}
