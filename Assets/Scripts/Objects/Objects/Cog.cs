using UnityEngine;

public class Cog : BaseObject, ICollactable,IInteractable
{
    [SerializeField] internal CogSlot _cogSlot;
    public void Interaction()
    {
        _cogSlot.currentCog = null;
    }
}