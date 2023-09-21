using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    private GachaSO currentGachaData;

    public static Action<GachaSO> OnGacha;

    public void Start()
    {
        OnGacha += StartGacha;
    }

    private void StartGacha(GachaSO gachaData)
    {

    }
}
