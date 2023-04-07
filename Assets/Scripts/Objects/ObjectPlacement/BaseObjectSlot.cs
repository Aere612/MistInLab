using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class BaseObjectSlot : MonoBehaviour,IInteractable
{
    [SerializeField] internal PlayerHandSo _playerHandSo;
    [SerializeField] internal Transform _slotTransform;
    [SerializeField] internal bool isFull;

    public virtual void Interaction()
    {
    }

    protected void PlaceTheObject(GameObject objectToPlace)
    {
        _playerHandSo.CurrentObject.transform.parent = null;
        objectToPlace.transform.position = _slotTransform.position;
        objectToPlace.transform.rotation = _slotTransform.rotation;
        _playerHandSo.CurrentObject = null;
    }
}
