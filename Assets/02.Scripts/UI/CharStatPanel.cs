using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharStatPanel : MonoBehaviour
{
    private Character currentData;
    [SerializeField]
    private TMP_Text atkText;
    [SerializeField]
    private TMP_Text defText;
    [SerializeField]
    private TMP_Text rangeText;
    [SerializeField]
    private TMP_Text atkSpeedText;
    [SerializeField]
    private TMP_Text lifeStealText;

    public void Init()
    {
        
    }

    public void Setting(Character newChar)
    {
        currentData = newChar;
         

    }
}
