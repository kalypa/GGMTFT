using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SO/Character")]
public class CharacterSO : ScriptableObject
{
    public int maxHP;
    public int maxMP;
    public int defaultAtk;
    public int defaultDef;
    public float defaultAtkSpeed;
    public int atkRange;

    public int upHP;
    public int upAtk;
    public int upDef;
    public float upAtkSpeed;
   
    public Sprite charSprite;

}
