using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private BaseObjectSlot objectSlot;
    public BaseObjectSlot ObjectSlot
    {
        get => objectSlot;
        set
        {
            if (value == null)
            {
                objectSlot.isFull = false;
                objectSlot = value;
            }
            else
            {
                objectSlot = value;
                objectSlot.isFull = true;
            }
        }
    }
}
