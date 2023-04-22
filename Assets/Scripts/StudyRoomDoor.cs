using UnityEngine;
using DG.Tweening;

public class StudyRoomDoor : MonoBehaviour, IInteractable
{
    [SerializeField] protected IngradientTypes _ingradientTypes;

    [SerializeField] private bool doorClosed = true;
    [SerializeField] private bool isLocked = true;
    [SerializeField] private Transform pivot;
    [SerializeField] private Rigidbody lockRb1;
    [SerializeField] private Rigidbody lockRb2;
    [SerializeField] private TrashDisabledStart lockTrash1;
    [SerializeField] private TrashDisabledStart lockTrash2;
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private AudioSource acidSfx;
    [SerializeField] private AudioSource doorSoundSfx;
    [SerializeField] private AudioClip doorOpenClip;
    [SerializeField] private AudioClip doorCloseClip;
    private void Awake()
    {
        lockTrash1.IsAvailableToCollect = false;
        lockTrash2.IsAvailableToCollect = false;
    }

    public void Interaction()
    {
        if (isLocked)
        {
            if (playerHandSo.CurrentObject == null) return;
            if (!playerHandSo.CurrentObject.TryGetComponent(out Vial vial) ||
                vial.BaseIngradiant != _ingradientTypes.Acid) return;
            isLocked = false;
            acidSfx.Play();
            lockTrash1.IsAvailableToCollect = true;
            lockTrash2.IsAvailableToCollect = true;
            lockRb1.isKinematic = false;
            lockRb2.isKinematic = false;
            return;
        }

        if (doorClosed)
        {
            doorSoundSfx.clip = doorOpenClip;
            doorSoundSfx.Play();
            doorClosed = false;
            pivot.DORotate(new Vector3(0, -90, 0f), 0.5f);
            return;
        }
        doorSoundSfx.clip = doorCloseClip;
        doorSoundSfx.Play();
        doorClosed = true;
        pivot.DORotate(new Vector3(0, 0, 0f), 0.5f);
    }
}