using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CropSystem : InputController
{
    public UnityAction<float> GainMoney;
    [Range(0,1)][SerializeField] private float CurrrentGrowth = 0;
    [SerializeField] private int Price;

    [SerializeField] private float DelayValue;
    private WaitForSeconds AutoDelay;
    private Coroutine autoGrowth;

    private void Start()
    {
        AutoDelay = new WaitForSeconds(DelayValue);
        ClickEvent += Growth;
        GainMoney += (value) => { stat.Money += (int)value; };
        autoGrowth = StartCoroutine(AutoGrowthCoroutine());
    }

    private void Growth(float value)
    {
        if (CurrrentGrowth >= 1)
        {
            CurrrentGrowth = 0;
            GainMoney?.Invoke(Price);
        }
        CurrrentGrowth += value / stat.Max;
    }

    private IEnumerator AutoGrowthCoroutine()
    {
        while (true)
        {
            yield return AutoDelay;
            ClickEvent?.Invoke(stat.AutoShot);
        }
    }
}
