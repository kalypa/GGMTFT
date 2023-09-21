using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharGachaData
{
    public CharacterSO character;
    public int weight;
}

public enum GachaType
{
    Nomal,
    Special,
}


public class GachaSO : MonoBehaviour
{
    public GachaType gachaType;
    [SerializeField]
    public List<CharGachaData> charGachaDatas;
}
