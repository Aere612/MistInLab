using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour,ICollactable
{
    public bool ısAvaible;

    bool ICollactable.IsAvaibleToCollect
    {
        get => ısAvaible;
        set => ısAvaible = value;
    }
}
