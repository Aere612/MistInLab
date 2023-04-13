using System;
using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable,IDeletable
{
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;

    private void Awake()
    {
        IsAvailableToCollect = true;
    }

    public void Interaction()
    {
        if (_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

    public bool IsAvailableToCollect { get; set; }
}
