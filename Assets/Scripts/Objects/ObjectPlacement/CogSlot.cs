public class CogSlot : BaseObjectSlot
{
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Cog>(out var _cog) || _currentObject != null) return;

        _currentObject = _cog;
        PlaceTheObject(_currentObject.gameObject,false);
        _currentObject._objectSlot = this;
    }

    public Cog CurrentObject
    {
        get => (Cog)_currentObject;
        set => _currentObject = value;
    }
}