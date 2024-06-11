using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NPC Information", fileName = "New NPC Info")]
public class NPCInfo : ScriptableObject
{
    public string npcName, npcDescription;
    public Sprite npcSprite;

    public int armourLevel, age;
    public bool isFriendly;
}
