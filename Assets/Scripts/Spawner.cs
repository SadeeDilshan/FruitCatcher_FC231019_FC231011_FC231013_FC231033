using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;       // drag the Fruit prefab here
    public GameObject bombPrefab;        // leave EMPTY for now (Part 9)
    public float spawnInterval = 1f;     // seconds between drops
    public float xRange = 8f;            // random left/right range
    [Range(0f, 1f)] public float bombChance = 0.25f; // 0.25 = 25%

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;         // count the seconds
        if (timer >= spawnInterval)
        {
            timer = 0f;                  // reset the stopwatch
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0f);

        GameObject toSpawn = fruitPrefab; // normally a fruit...
        if (bombPrefab != null && Random.value < bombChance)
        {
            toSpawn = bombPrefab;        // ...sometimes a bomb
        }
        Instantiate(toSpawn, spawnPos, Quaternion.identity);
    }
}
