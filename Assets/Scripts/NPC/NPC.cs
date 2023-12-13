using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{

    public event EventHandler<OnEmotionChangedEventArgs> OnEmotionChanged;

    public class OnEmotionChangedEventArgs : EventArgs
    {
        public NpcEmotion NewEmotion { get; set; }
    }
    public enum NpcType
    {
        Alcoholic,
        Homeless,
        Lonely,
        DrugAddict
    }

    public enum NpcEmotion
    {
        Sad,
        Neutral,
        Happy
    }

    public NpcType type { get; private set; }
    private NpcEmotion emotion;

    public NpcEmotion Emotion 
    {
        get
        {
            return emotion;
        }
        set
        {
            emotion = value;
            OnEmotionChanged?.Invoke(this, new OnEmotionChangedEventArgs { NewEmotion = emotion});
        }
    }

    [SerializeField] private NpcType npcType;

    /*private void Awake()
    {
        System.Random rand = new System.Random();

        int npcTypeNum = rand.Next(0, Enum.GetValues(typeof(NpcType)).Length);
        type = (NpcType)npcTypeNum;
    }*/

    private void Awake()
    {
        type = npcType;
    }

}
