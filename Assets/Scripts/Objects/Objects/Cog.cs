using System;
using UnityEngine;

public class Cog : BaseObject,IInteractable,ICollactable
{
    [SerializeField] private AudioSource pickUpSfx;
    public void Interaction()
    {
        pickUpSfx.Play();
        if(_objectSlot!=null) _objectSlot._currentObject = null;
    }

    private void Awake()
    {
        IsAvailableToCollect = true;
    }

    public bool IsAvailableToCollect { get; set; } = true;
}