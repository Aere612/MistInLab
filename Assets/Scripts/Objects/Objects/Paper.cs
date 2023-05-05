using UnityEngine;

public class Paper : BaseObject, ICollactable, IInteractable
{
    public bool IsAvailableToCollect { get; set; } = true;
    [SerializeField] private AudioSource pickUpSound;
    public void Interaction()
    {
        pickUpSound.Play();
        if (!IsAvailableToCollect) return;
        if (_objectSlot )
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }
}