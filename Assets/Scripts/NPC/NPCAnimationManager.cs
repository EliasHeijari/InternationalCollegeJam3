using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void Awake()
    {
        NPC npc = GetComponent<NPC>();
        npc.OnEmotionChanged += NPC_OnEmotionChnaged;
    }
    private void NPC_OnEmotionChnaged(object sender, NPC.OnEmotionChangedEventArgs e)
    {
        animator.ResetTrigger("IsSad");
        animator.ResetTrigger("IsNeutral");
        animator.ResetTrigger("IsHappy");
        switch (e.NewEmotion)
        {
            case NPC.NpcEmotion.Sad:
                animator.SetTrigger("IsSad");
                break;

            case NPC.NpcEmotion.Neutral:
                animator.SetTrigger("IsNeutral");
                break;
            case NPC.NpcEmotion.Happy:
                animator.SetTrigger("IsHappy");
                break;
            default:
                Debug.LogWarning("Emotion was not any of the emotions");
                break;
        }

    }
}
