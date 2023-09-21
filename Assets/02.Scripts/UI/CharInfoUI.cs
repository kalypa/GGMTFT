using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharInfoUI : MonoBehaviour
{
    private Character currentCharacter;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private CharStatPanel statPanel;
    [SerializeField]
    private TMP_Text hpText;
    //[SerializeField]
    //private HPBar hpBar;
    [SerializeField]
    private void Start()
    {
        Init();
    }

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

    public void Show()
    {
        EventManager.StartListening(EUIEvent.BackgroundPaenlClick, Hide);
        gameObject.SetActive(true);
    }

    public void Hide(object[] ps = null)
    {
        EventManager.StopListening(EUIEvent.BackgroundPaenlClick, Hide);

        gameObject.SetActive(false);
    }
}
