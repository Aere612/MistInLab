using UnityEngine;


public class Vial : BaseObject,IInteractable,IDeletable
{
    [SerializeField] private IngradientsSO baseIngradiant;
    [SerializeField] private IngradientsSO sideIngradiant;

    [SerializeField] private MeshRenderer baseIngradiantMesh;
    [SerializeField] private MeshRenderer sideIngradiantMesh;
    
    [SerializeField] internal AudioSource vialPickUpSfx;

    
    public IngradientsSO BaseIngradiant
    {
        get => baseIngradiant;
        set
        {
            baseIngradiant = value;
            baseIngradiantMesh.material = baseIngradiant.Material;
        }
    }

    public IngradientsSO SideIngradiant
    {
        get => sideIngradiant;
        set
        {
            sideIngradiant = value;
            sideIngradiantMesh.material = sideIngradiant.Material;
        }
    }


    public void Interaction()
    {
        vialPickUpSfx.Play();
        if (_objectSlot)
            _objectSlot._currentObject = null;
        _objectSlot = null;
    }

}
