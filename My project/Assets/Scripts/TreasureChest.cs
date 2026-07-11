using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChest : MonoBehaviour
{
    bool canOpen = false;

    void Update()
    {
        if(canOpen && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}