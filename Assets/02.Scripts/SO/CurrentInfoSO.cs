using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CurrentInfo")]
public class CurrentInfoSO : ScriptableObject
{
    public int currentChampionLimit = 1;

    public int currentChampionCount = 0;

    public int currentGold = 5;

    public int currentHP = 100;
}
