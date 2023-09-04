using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image barImage;

    private int currentHP;

    private int maxHP;

    public void Init(int newHP)
    {
        maxHP = newHP;
       
    }
}
