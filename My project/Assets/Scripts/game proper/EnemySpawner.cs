using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

public GameObject ChasePrefab;
public GameObject ChargerPrefab;
public GameObject ShooterPrefab;
private float ChasePrefabInterval = 2f;

private float ChargerPrefabInterval = 5f;

private float ShooterPrefabInterval = 8f;

void Start()
{
    //testing out resource load
    ShooterPrefab = Resources.Load("prefabs/Cube") as GameObject;


    StartCoroutine (spawnEnemy (ChasePrefabInterval, ChasePrefab));
    StartCoroutine (spawnEnemy (ChargerPrefabInterval, ChargerPrefab));
    StartCoroutine (spawnEnemy (ShooterPrefabInterval, ShooterPrefab));
}

private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds (interval);
        Instantiate (enemy, new Vector3(Random.Range(20, 80), 8, Random.Range(20,80)), Quaternion.identity);
        StartCoroutine (spawnEnemy (interval, enemy));
    }
}
