using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public UnityAction<float> ClickEvent;
    
    private Input _input;
    protected Playerstat stat;

    protected virtual void Awake()
    {
        stat = GameManager.Instance.stat;
    }

    private void OnEnable()
    {
        _input = new Input();

        _input.Click.ClickAction.started += Click;
        
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Click.ClickAction.started -= Click;
        
        _input.Disable();
    }

    private void Click(InputAction.CallbackContext context)
    {
        ClickEvent?.Invoke(stat.PerShot);
    }
}
