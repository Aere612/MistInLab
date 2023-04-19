public class Cog : BaseObject, ICollactable,IInteractable
{
    private void Awake()
    {
        IsAvailableToCollect = true;
    }

    public void Interaction()
    {
        _objectSlot._currentObject = null;
    }

    public bool IsAvailableToCollect { get; set; }
}