using UnityEngine;

public class RandomTrashSpawner : MonoBehaviour
{
    [Header("Prefab Categories")]
    public GameObject[] organicTrash;     // pisang, daun, dll
    public GameObject[] inorganicTrash;   // kaleng, plastik, dll
    public GameObject[] hazards;          // paku, botol pecah, dll

    [Header("Spawn Amount")]
    public int organicCount = 5;
    public int inorganicCount = 5;
    public int hazardCount = 3;

    // [Header("Spawn Area Settings")]
    // public bool useSpawnPoints = false;
    // public Transform[] spawnPoints; // titik spawn tertentu

    public Vector2 minSpawnPos; // jika random area
    public Vector2 maxSpawnPos;

    void Start()
    {
        SpawnObjects(organicTrash, organicCount);
        SpawnObjects(inorganicTrash, inorganicCount);
        SpawnObjects(hazards, hazardCount);
    }

    void SpawnObjects(GameObject[] prefabArray, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // pilih prefab random
            GameObject prefab = prefabArray[Random.Range(0, prefabArray.Length)];

            Vector2 spawnPos;

            // if (useSpawnPoints && spawnPoints.Length > 0)
            // {
            //     // spawn di titik tertentu
            //     Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //     spawnPos = point.position;
            // }
            // else
            {
                // random spawn area
                float x = Random.Range(minSpawnPos.x, maxSpawnPos.x);
                float y = Random.Range(minSpawnPos.y, maxSpawnPos.y);
                spawnPos = new Vector2(x, y);
            }

            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }

    // [Header("Pickups")]
    // public GameObject[] pickupPrefabs;   // all possible pickups
    // public float spawnInterval = 2f;

    // [Header("Spawn Area")]
    // public Vector2 spawnAreaMin;
    // public Vector2 spawnAreaMax;

    // private void Start()
    // {
    //     InvokeRepeating(nameof(SpawnPickup), 1f, spawnInterval);
    // }

    // void SpawnPickup()
    // {
    //     // choose random prefab
    //     int randomIndex = Random.Range(0, pickupPrefabs.Length);
    //     GameObject prefabToSpawn = pickupPrefabs[randomIndex];

    //     // random position
    //     float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
    //     float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
    //     Vector2 spawnPos = new Vector2(x, y);

    //     Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    // }
}
