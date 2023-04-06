using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] private Transform playerCameraTransform;

    private void Start()
    {
        _playerHandSo.CurrentObject = null;
    }

    public void CastRay()
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out var hit, 10)) return;
        if (hit.collider.TryGetComponent<ICollactable>(out var _clickedObject) && _playerHandSo.CurrentObject == null)
        {
            PutObjectToHand(hit.collider.gameObject);
            if (_clickedObject.ObjectSlot != null)
                _clickedObject.ObjectSlot = null;
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

    public void DropTheObject()
    {
        Debug.Log("Dropped");
        var rigidbody = _playerHandSo.CurrentObject?.GetComponent<Rigidbody>();
        _playerHandSo.CurrentObject.transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(_playerHandSo.CurrentObject.transform.forward * 200);
        _playerHandSo.CurrentObject = null;
    }
}