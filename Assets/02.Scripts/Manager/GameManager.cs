using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    #region Money
    private int money;

    public int GetMoney { get => money; }

    public int SetMoney
    {
        set
        {
            money = value;
        }
    }

    public int AddMoney(int value)
    {
        money += value;
        return money;
    }

    public bool SpendMoney(int value)
    {
        if(money - value < 0)
        {
            return false;
        }

        money -= value;

        return true;
    }
    #endregion

}
