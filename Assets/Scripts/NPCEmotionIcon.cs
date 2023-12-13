using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCEmotionIcon : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite[] emotionImages;
    private void Awake()
    {
        if (!transform.parent.parent.TryGetComponent(out NPC npc))
        {
            Debug.LogWarning("Couldn't get npc script from parents parent");
        }
        iconImage = GetComponent<Image>();
        npc.OnEmotionChanged += NPC_OnEmotionChanged;
    }

    private void NPC_OnEmotionChanged(object sender, NPC.OnEmotionChangedEventArgs e)
    {
        switch(e.NewEmotion)
        {
            case NPC.NpcEmotion.Sad:
                iconImage.sprite = emotionImages[0];
                break;
            case NPC.NpcEmotion.Neutral:
                iconImage.sprite = emotionImages[1];
                break;
            case NPC.NpcEmotion.Happy:
                iconImage.sprite = emotionImages[2];
                break;
        }
    }
}
