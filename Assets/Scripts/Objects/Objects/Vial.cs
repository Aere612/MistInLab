using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable,IDeletable
{
    [SerializeField] private Ingradients _baseIngradiant;
    [SerializeField] private Ingradients _sideIngradiant;
    public bool IsAvailableToCollect { get; set; } = true;

    public void Interaction()
    {
        if (_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

}
