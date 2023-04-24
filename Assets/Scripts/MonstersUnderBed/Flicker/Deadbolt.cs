using DG.Tweening;
using UnityEngine;

public class Deadbolt : MonoBehaviour, IInteractable
{
    [SerializeField] private JanitorRoomDoor janitorRoomDoor;
    [SerializeField] private Transform pivot;
    [SerializeField] private AudioSource audioSource;


    public void Interaction()
    {
        if (!janitorRoomDoor.DoorClosed) return;
        if (janitorRoomDoor.DoorLocked) Unlock();
        else Lock();
        audioSource.Play();
    }

    private void Lock()
    {
        
        janitorRoomDoor.DoorLocked = true;
        janitorRoomDoor.DoorLocked = janitorRoomDoor.DoorLocked;
        pivot.DORotate(new Vector3(90, 0, 0f), 0.5f);
    }

    private void Unlock()
    {
        janitorRoomDoor.DoorLocked = false;
        janitorRoomDoor.DoorLocked = janitorRoomDoor.DoorLocked;
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f);
    }
}