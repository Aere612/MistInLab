using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour,IInteractable,ICollactable
{
    [SerializeField] private PickUpTutorial pickUpTutorial;
    [SerializeField] private bool once=true;
    public void Interaction()
    {
        if (!once) return;
        once = false;
        pickUpTutorial.Vanish();
    }

    private void Awake()
    {
        pickUpTutorial.gameObject.SetActive(true);
        IsAvailableToCollect = true;
    }

    public bool IsAvailableToCollect { get; set; }
}
