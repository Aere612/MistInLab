using System;
using UnityEngine;

public class Cog : BaseObject, ICollactable,IInteractable
{
    private void Awake()
    {
        IsAvaibleToCollect = true;
    }

    public void Interaction()
    {
        _objectSlot._currentObject = null;
    }

    public bool IsAvaibleToCollect { get; set; }
}