using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable
{
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;
    public void Interaction()
    {
        if(_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }
}
