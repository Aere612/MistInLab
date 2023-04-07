using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputController : MonoBehaviour
{
    private PlayerControls _playerControls;

    [SerializeField] private GameEvent _onMouseClicked;
    [SerializeField] private GameEvent _onQPressed;
    private void Start()
    {
        _playerControls = new PlayerControls();
        
        _playerControls.Player.Press.started += InvokeMouseClickEvent;
        _playerControls.Player.DropObject.started += InvokeQPressedEvent;
        
        
        _playerControls.Enable();
    }
    
    
    public void InvokeMouseClickEvent(InputAction.CallbackContext context)
    {
        _onMouseClicked.Raise();
    }

    public void InvokeQPressedEvent(InputAction.CallbackContext context)
    {
        _onQPressed.Raise();
    }
}
