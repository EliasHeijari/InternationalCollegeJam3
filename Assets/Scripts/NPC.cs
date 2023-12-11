using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
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

    public NpcEmotion emotion { get; set; }

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
