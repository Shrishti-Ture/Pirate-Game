using UnityEngine;
using TMPro;

public class TreasureManager : MonoBehaviour
{
    public static TreasureManager Instance;

    [Header("UI")]
    public GameObject cluePanel;
    public TMP_Text clueText;

    [Header("Treasure")]
    public GameObject treasureChest;

    private int clueIndex = 0;

    string[] clues =
    {
        "Captain's Log:\n\nSail to Skull Island and defeat its guards.",
        "Good!\nNow sail to Coral Reef and defeat the pirates there.",
        "Excellent!\nThe treasure awaits near Treasure Island.",
        "Congratulations!\nCollect the treasure!"
    };

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cluePanel.SetActive(true);
        clueText.text = clues[0];

        treasureChest.SetActive(false);
    }

    public void NextClue()
    {
        clueIndex++;

        if(clueIndex >= clues.Length)
            return;

        clueText.text = clues[clueIndex];

        if(clueIndex == clues.Length-1)
            treasureChest.SetActive(true);
    }
}