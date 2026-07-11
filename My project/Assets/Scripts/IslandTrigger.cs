using UnityEngine;

public class IslandTrigger : MonoBehaviour
{
    public int clueNumber;

    public int enemiesToDestroy = 2;

    bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(activated)
            return;

        if(!other.CompareTag("Player"))
            return;

        if(EnemyCounter.enemiesDestroyed < enemiesToDestroy)
            return;

        activated = true;

        TreasureManager.Instance.NextClue();

        gameObject.SetActive(false);
    }
}