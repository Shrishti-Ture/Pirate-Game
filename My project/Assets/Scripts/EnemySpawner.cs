using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int enemiesToSpawn = 3;

    void Start()
    {
        if (spawnPoints.Length == 0)
            return;

        int count = Mathf.Min(enemiesToSpawn, spawnPoints.Length);

        // Shuffle spawn points
        Transform[] shuffled = (Transform[])spawnPoints.Clone();
        for (int i = 0; i < shuffled.Length; i++)
        {
            int j = Random.Range(i, shuffled.Length);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }

        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab,
                        shuffled[i].position,
                        shuffled[i].rotation);
        }
    }
}