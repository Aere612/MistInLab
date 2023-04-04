using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    private int _layerMask;
    public GameObject Player, ScreenCam, PlayerCam;

    private void Start()
    {
        _layerMask = 1 << 2;
        _layerMask = ~_layerMask;
    }

    public virtual void OnPointerDown(PointerEventData pointerData)
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 3);
        
        if (!hit.collider.TryGetComponent<IInteractable>(out var interactedObject)) return;
        interactedObject.Interaction();
    }
}
