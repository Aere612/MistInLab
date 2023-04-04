using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameEvent onMouseClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseClick.Raise();
        }
    }
    /*Altay: Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 3);
    
    if (!hit.collider.TryGetComponent<IInteractable>(out var interactedObject)) return;
    interactedObject.Interaction();*/
}