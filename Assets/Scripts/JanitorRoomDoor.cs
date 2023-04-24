using UnityEngine;
using DG.Tweening;

public class JanitorRoomDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private bool doorClosed = true;
    [SerializeField] private bool doorLocked;
    [SerializeField] private Transform pivot;
    [SerializeField] private AudioSource doorSoundSfx;
    [SerializeField] private AudioClip doorOpenClip;
    [SerializeField] private AudioClip doorCloseClip;

    public bool DoorClosed => doorClosed;

    public bool DoorLocked
    {
        get => doorLocked;
        set => doorLocked = value;
    }

    public void Interaction()
    {
        if (DoorLocked) return;
        if (DoorClosed)
        {
            doorSoundSfx.clip = doorOpenClip;
            doorSoundSfx.Play();
            doorClosed = false;
            pivot.DORotate(new Vector3(0, 90, 0f), 0.5f);
            return;
        }
        doorSoundSfx.clip = doorCloseClip;
        doorSoundSfx.Play();
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f).OnComplete(()=>doorClosed = true);
    }
}