using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static int enemiesDestroyed;

    void Awake()
    {
        enemiesDestroyed = 0;
    }

    public static void EnemyKilled()
    {
        enemiesDestroyed++;
    }
}