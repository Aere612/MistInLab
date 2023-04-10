using UnityEngine;
using DG.Tweening;

public class S_Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool doorClosed = true;
    [SerializeField] private bool isLocked = true;
    [SerializeField] private Transform pivot;

    public bool DoorClosed => doorClosed;

    public void Interaction()
    {
        if (isLocked) return;
        if (DoorClosed)
        {
            doorClosed = false;
            pivot.DORotate(new Vector3(0, -90, 0f), 0.5f);
            return;
        }

        doorClosed = true;
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f);
    }
}