using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat
{
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int atkRange;
    public float atkSpeed;
    public int speed;
    public float lifeSteal;
}


public class Character : MonoBehaviour
{
    protected CharacterSO currentData;
    protected CharacterStat charStat;

    protected int charLv; // 캐릭터 돌파
    public int CharLV;

    public CharacterStat GetStat
    {
        get => charStat;
    }

    public void Init(CharacterSO newData)
    {
        currentData = newData;
        charLv = 1;
        charStat.hp = currentData.maxHP;
        charStat.mp = currentData.maxMP;
        charStat.lifeSteal = 0;
        charStat.atkSpeed = currentData.defaultAtkSpeed;
        charStat.atk = currentData.defaultAtk;
        charStat.atkRange = currentData.atkRange;
        charStat.def = currentData.defaultDef;
    }

    public CharacterSO GetData()
    {
        return currentData;
    }
}
