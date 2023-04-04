using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private Transform playerCameraTransform;

    public void CastRay()
    {
        if(!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out var hit, 10)) return;
    
        if (hit.collider.TryGetComponent<Vial>(out _))
        {
            Debug.Log("Collactable");
            hit.collider.gameObject.transform.position = playerHandTransform.position;
            hit.collider.gameObject.transform.parent = playerCameraTransform;
            _playerHandSo.CurrentObject = hit.collider.gameObject;
        }

        if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interaction();
        }
    }
}
