using UnityEngine;

public class CogSlot : BaseObjectSlot
{
    [SerializeField] private AudioSource cogInsertSfx;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Cog>(out var _cog) || _currentObject != null) return;
        cogInsertSfx.Play();
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