using System;
using UnityEngine;

public class Cog : BaseObject, ICollactable,IInteractable
{
    private void Awake()
    {
        IsAvaible = true;
    }

    public void Interaction()
    {
        _objectSlot._currentObject = null;
    }

    public bool IsAvaible { get; set; }
}