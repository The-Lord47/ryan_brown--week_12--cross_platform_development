using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion Info", fileName = "New Potion Info")]
public class PotionInfo : ScriptableObject
{
    public string potionName;
    public int potionValue;
    public Color32 potionColor;
}
