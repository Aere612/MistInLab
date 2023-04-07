using UnityEngine;


public class Vial : BaseObject,ICollactable,IInteractable
{
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;
    [SerializeField] internal VialSlot _vialSlot;
    public void Interaction()
    {
        if(_vialSlot)
            _vialSlot.currentVial = null;
        _vialSlot = null;
    }
}
