using UnityEngine;

public class RandomTrashSpawner : MonoBehaviour
{
    [Header("Pickups")]
    public GameObject[] pickupPrefabs;   // all possible pickups
    public float spawnInterval = 2f;

    [Header("Spawn Area")]
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPickup), 1f, spawnInterval);
    }

    void SpawnPickup()
    {
        // choose random prefab
        int randomIndex = Random.Range(0, pickupPrefabs.Length);
        GameObject prefabToSpawn = pickupPrefabs[randomIndex];

        // random position
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
