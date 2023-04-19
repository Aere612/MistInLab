public class VialSlot : BaseObjectSlot
{
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial) || _currentObject != null) return;
        
        _currentObject = _vial;
        PlaceTheObject(_currentObject.gameObject);
        _currentObject._objectSlot = this;
    }

    public Vial CurrentObject
    {
        get => (Vial)_currentObject;
        set => _currentObject = value;
    }
}