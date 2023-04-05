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
    
        if (hit.collider.TryGetComponent<ICollactable>(out _))
        {
            PutObjectToHand(hit.collider.gameObject);
        }

        if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interaction();
        }
    }

    private void PutObjectToHand(GameObject objectToPut)
    {
        _playerHandSo.CurrentObject = objectToPut;
        _playerHandSo.CurrentObject.transform.parent = playerCameraTransform;
        _playerHandSo.CurrentObject.transform.position = playerHandTransform.position;
        _playerHandSo.CurrentObject.transform.rotation = playerCameraTransform.rotation;
        _playerHandSo.CurrentObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void DropTheObject() //Altay: Q'ya basılınca düşür.
    {
        _playerHandSo.CurrentObject.transform.parent = null;
        _playerHandSo.CurrentObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
