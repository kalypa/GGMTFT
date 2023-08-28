using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharInfoUI : MonoBehaviour
{
    private Character currentCharacter;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private CharStatPanel statPanel;
    [SerializeField]
    private TMP_Text hpText;
    [SerializeField]

    public void Init() 
    {
        EventManager.StartListening(ECharInfoUI.ShowInfoUI, Setting);
    }


    private void Setting(object[] ps)
    {
        if(!(ps[0] is Character))
        {
            Debug.Log($"CharInfoUI의 Setting 함수에서 매게변수를 Character로 변경할 수 없습니다.");
            return;
        }

    }

    public void Setting(Character newChar)
    {
        currentCharacter = newChar;
    }


}
