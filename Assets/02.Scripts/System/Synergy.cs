using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SynergyType
{
    None = -1,
    Fire,

}

public class Synergy : MonoBehaviour
{
    public string displayName = "name";

    public Sprite icon;

    public ChampionBonus championBonus;
}
