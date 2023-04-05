using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameEvent onMouseClick;
    [SerializeField] private GameEvent onQPressed;
    
    [SerializeField] private InputActionAsset actions;

    private PlayerControls _playerControls;
    private void Start()
    {
        _playerControls = new PlayerControls();
        _playerControls.Player.Press.started += InvokeMouseClickEvent;
        _playerControls.Player.Press.canceled += InvokeQPressedEvent;
        _playerControls.Enable();
    }

    public void InvokeMouseClickEvent(InputAction.CallbackContext context)
    {
        Debug.Log("Worked");
    }

    public void InvokeQPressedEvent(InputAction.CallbackContext context)
    {
        Debug.Log("Runned");
    }
    
}