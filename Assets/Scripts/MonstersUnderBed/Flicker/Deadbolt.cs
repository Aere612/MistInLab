using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadbolt : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked = false;

    public bool IsLocked => isLocked;

    public void Interaction()
    {
        if (IsLocked) Unlock();
        else Lock();
    }

    private void Lock()
    {
        isLocked = true;
        //TODO Lock anim
        Debug.Log("Locked");
    }
    private void Unlock()
    {
        isLocked = false;
        //TODO Unlock anim
        Debug.Log("Unlocked");
    }
}