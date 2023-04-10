using System;
using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable,IDeletable
{
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;

    private void Awake()
    {
        IsAvaible = true;
    }

    public void Interaction()
    {
        if(_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

    public bool IsAvaible { get; set; }
}
