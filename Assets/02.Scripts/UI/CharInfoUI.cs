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
        InputManager.Inst.AddMouseInput(EMouseType.LeftClick, CheckClose);
    }


    private void Setting(object[] ps)
    {
        if(!(ps[0] is Character))
        {
            Debug.Log($"CharInfoUI의 Setting 함수에서 매게변수를 Character로 변경할 수 없습니다.");
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

    private void CheckClose()
    {
        Debug.Log("CheckClose");
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = Input.mousePosition;
        List<RaycastResult> hits = new List<RaycastResult>();

        Debug.Log($"hits Count : {hits.Count}");
        if(hits.Count == 0)
        {
            return;
        }
        EventSystem.current.RaycastAll(data, hits);
        if (!Define.ExistInFirstHits(gameObject, hits[0]))
        {
            Debug.Log("Hide");
            Hide();
        }
    }

    public void Show()
    {

    }

    public void Hide()
    {
        gameObject.SetActive(false);
        InputManager.Inst.RemoveMouseInput(EMouseType.LeftClick, CheckClose);
    }
}
