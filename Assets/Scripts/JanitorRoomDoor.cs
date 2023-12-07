using UnityEngine;
using DG.Tweening;
using UnityEngine.ProBuilder.Shapes;

public class JanitorRoomDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private bool doorClosed = true;
    [SerializeField] private bool doorLocked;
    [SerializeField] private Transform pivot;
    [SerializeField] private AudioSource doorSoundSfx;
    [SerializeField] private AudioClip doorOpenClip;
    [SerializeField] private AudioClip doorCloseClip;
    [SerializeField] private bool doorNotAvailable;

    public bool DoorClosed => doorClosed;

    public bool once=false;

    public bool DoorLocked
    {
        get => doorLocked;
        set => doorLocked = value;
    }

    public bool DoorNotAvailable => doorNotAvailable;

    public void Interaction()
    {
        if (DoorNotAvailable) return;
        if (DoorLocked) return;
        doorNotAvailable = true;
        Door();
    }
   

    private void Door()
    {
                if (DoorClosed)
                {
                    doorSoundSfx.clip = doorOpenClip;
                    doorSoundSfx.Play();
                    pivot.DORotate(new Vector3(0, 90, 0f), 0.5f).OnComplete(()=>
                    {
                        doorClosed = false;
                        doorNotAvailable = false;
                    });
                    return;
                }
                doorSoundSfx.clip = doorCloseClip;
                doorSoundSfx.Play();
                pivot.DORotate(new Vector3(0, 0, 0f), 0.5f).OnComplete(()=>
                {
                    doorClosed = true;
                    doorNotAvailable = false;
                });
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && once==false)
        {
            Door();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        once= true;
    }
}