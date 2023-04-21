using UnityEngine;


public class Vial : BaseObject,IInteractable,IDeletable
{
    [SerializeField] internal IngradientsSO baseIngradiant;
    [SerializeField] internal IngradientsSO sideIngradiant;
    [SerializeField] internal AudioSource vialPickUpSfx;

    public void Interaction()
    {
        vialPickUpSfx.Play();
        if (_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

}
