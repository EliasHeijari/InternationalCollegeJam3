using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField] private NPC[] npcs;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        foreach (NPC npc in npcs)
        {
            npc.OnEmotionChanged += Npc_OnEmotionChanged;
        }
    }

    private void Npc_OnEmotionChanged(object sender, NPC.OnEmotionChangedEventArgs e)
    {
        bool hasWon = false;
        foreach (NPC npc in npcs)
        {
            hasWon = npc.Emotion == NPC.NpcEmotion.Happy;
            if (!hasWon)
                break;
        }
        if (hasWon)
        {
            WonGame();
        }

    }

    private void WonGame()
    {
        audioSource.Play();
        StartCoroutine(PlayMainMenu());
    }

    IEnumerator PlayMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
