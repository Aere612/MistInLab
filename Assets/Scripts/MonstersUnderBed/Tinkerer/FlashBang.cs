using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBang : MonoBehaviour,IInteractable
{
    [SerializeField] private Tinkerer tinkerer;

    public void Interaction()
    {
        tinkerer.FlashBanged();
    }
}
