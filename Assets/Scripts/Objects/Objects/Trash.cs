using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour,ICollactable
{
    public bool ısAvaible;

    bool ICollactable.IsAvaible
    {
        get => ısAvaible;
        set => ısAvaible = value;
    }
}
