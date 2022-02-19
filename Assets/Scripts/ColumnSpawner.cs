using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColumnSpawner : MonoBehaviour
{
    [SerializeField] private GameObject columnPrefab;
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Transform playerPosition;
    //10 2 up
    //-10 -2
    private List<GameObject> columns = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnColumns());
    }

    private void Update()
    {
        if (columns[0].transform.position.x + 8f < playerPosition.position.x)
        {
            DeleteColumns();
        }
    }

    IEnumerator SpawnColumns()
    {
        var newColumnUp = Instantiate(columnPrefab, new Vector3(spawnPosition.position.x, Random.Range(2f, 10f), 0f),
            Quaternion.identity);
        columns.Add(newColumnUp);
        yield return new WaitForSeconds(3f);
        var newColumnDown = Instantiate(columnPrefab, new Vector3(spawnPosition.position.x, Random.Range(-10f, -2f), 0f),
            Quaternion.identity);
        columns.Add(newColumnDown);
        yield return new WaitForSeconds(3f);
        RepeatCoroutine();
    }

    private void RepeatCoroutine()
    {
        StartCoroutine(SpawnColumns());
    }

    private void DeleteColumns()
    {
        Destroy(columns[0]);
        columns.RemoveAt(0);
    }
}
