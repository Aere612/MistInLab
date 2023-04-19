using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable,IDeletable
{
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;
    public bool IsAvailableToCollect { get; set; } = true;

    public void Interaction()
    {
        if (_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

}
