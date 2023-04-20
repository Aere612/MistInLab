using UnityEngine;

public class VialSlot : BaseObjectSlot
{
    [SerializeField] private bool placeReverse;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial) || _currentObject != null) return;
        
        _currentObject = _vial;
        PlaceTheObject(_currentObject.gameObject,placeReverse);
        _currentObject._objectSlot = this;
    }

    public Vial CurrentObject
    {
        get => (Vial)_currentObject;
        set => _currentObject = value;
    }
}