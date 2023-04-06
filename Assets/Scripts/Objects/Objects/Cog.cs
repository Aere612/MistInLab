using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour, ICollactable
{
    private BaseObjectSlot objectSlot;
    public BaseObjectSlot ObjectSlot
    {
        get => objectSlot;
        set
        {
            objectSlot.isFull = value != null;
            objectSlot = value;
        }
    }
}