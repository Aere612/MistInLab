using UnityEngine;

public class Cog : BaseObject, ICollactable,IInteractable
{
    public void Interaction()
    {
        _objectSlot._currentObject = null;
    }
}