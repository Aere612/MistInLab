using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactions : MonoBehaviour, IPointerDownHandler
{
    int layerMask;
    public GameObject Player, ScreenCam, PlayerCam;

    private void Start()
    {
        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }

    public virtual void OnPointerDown(PointerEventData pointerData)
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 3, layerMask);
        if (!hit.collider.TryGetComponent<IInteractable>(out var interactedObject)) return;
        interactedObject.Interaction();
    }
}