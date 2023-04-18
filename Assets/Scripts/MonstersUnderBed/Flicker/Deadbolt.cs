using DG.Tweening;
using UnityEngine;

public class Deadbolt : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked = false;
    [SerializeField] private JanitorRoomDoor janitorRoomDoor;
    [SerializeField] private Transform pivot;

    public bool IsLocked => isLocked;

    public void Interaction()
    {
        if (!janitorRoomDoor.DoorClosed) return;
        if (IsLocked) Unlock();
        else Lock();
    }

    private void Lock()
    {
        isLocked = true;
        pivot.DORotate(new Vector3(90, 0, 0f), 0.5f);
    }

    private void Unlock()
    {
        isLocked = false;
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f);
    }
}