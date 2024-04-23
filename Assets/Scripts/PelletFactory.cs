using System;
using System.Collections.Generic;
using UnityEngine;

public class PelletFactory : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private List<GameObject> pelletPrefabs;

    [SerializeField] Transform spawnPointContainer;
    [SerializeField] private List<Transform> spawnPoints;

    private int lastSpawnIndex = -1;

    private List<GameObject> pelletPool = new List<GameObject>();

    private void Start()
    {
        if (spawnPoints.Count == 0)
        {
            spawnPoints.AddRange(spawnPointContainer.GetComponentsInChildren<Transform>());
        }
        InvokeRepeating(nameof(Spawn), spawnInterval, spawnInterval);
    }

    public void Spawn()
    {
        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        while (spawnPointIndex == lastSpawnIndex)
        {
            spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        }
        int pelletIndex = UnityEngine.Random.Range(0, pelletPrefabs.Count);

        GameObject pelletInPool = pelletPool.Find((p) => p.activeSelf == false);
        Debug.Log(pelletInPool);
        if (pelletInPool != null)
        {
            pelletInPool.transform.position = spawnPoints[spawnPointIndex].position;
            pelletInPool.SetActive(true);
        }
        else
        {
            Debug.Log(pelletPrefabs[pelletIndex]);
            Debug.Log(spawnPoints[spawnPointIndex].position);
            Debug.Log(spawnPoints[spawnPointIndex].rotation);
            Debug.Log(gameObject.transform);
            GameObject spawnedPellet = Instantiate(
                pelletPrefabs[pelletIndex],
                spawnPoints[spawnPointIndex].position,
                spawnPoints[spawnPointIndex].rotation,
                gameObject.transform
            );
            pelletPool.Add(spawnedPellet);
        }
    }
}
