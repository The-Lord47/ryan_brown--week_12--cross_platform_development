using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public GameObject npcCard;
    public TMP_Text npcName, npcDescription, npcArmour, npcAge, npcFriendliness;
    public Image npcArtwork;
    public GameObject gameOverScreen;


    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void ShowCharCard(NPCInfo npcStats)
    {
        npcCard.SetActive(true);
        npcName.text = npcStats.npcName;
        npcDescription.text = npcStats.npcDescription;
        npcArmour.text = $"Armour Rating: {npcStats.armourLevel}";
        npcAge.text = $"Age: {npcStats.age}";
        npcArtwork.sprite = npcStats.npcSprite;

        if (npcStats.isFriendly)
        {
            npcFriendliness.text = "I will protect the sanctity of life and face against any who dares threaten it!";
        }
        else
        {
            npcFriendliness.text = "If you bleed, I will feed...";
        }
    }

    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
