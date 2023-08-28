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
            Debug.Log($"CharInfoUI�� Setting �Լ����� �ŰԺ����� Character�� ������ �� �����ϴ�.");
            return;
        }

        Setting(ps[0] as Character);

    }

    public void Setting(Character newChar)
    {
        currentCharacter = newChar;
    }

    private void OnDestroy()
    {
        EventManager.StopListening(ECharInfoUI.ShowInfoUI, Setting);
    }



}
