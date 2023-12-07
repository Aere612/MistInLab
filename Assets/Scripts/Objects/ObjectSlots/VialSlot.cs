using UnityEngine;

public class VialSlot : BaseObjectSlot
{
    [SerializeField] private bool placeReverse;
    [SerializeField] private AudioSource vialInsertSfx;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial) || _currentObject != null) return;
        vialInsertSfx.Play();
        _currentObject = _vial;
        PlaceTheObject(_currentObject.gameObject,placeReverse);
        _currentObject._objectSlot = this;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vial"))
        {
            if (other.gameObject == null) return;
            if (!other.gameObject.TryGetComponent<Vial>(out var _vial) || _currentObject != null) return;
            vialInsertSfx.Play();
            _currentObject = _vial;
            PlaceTheObject(_currentObject.gameObject, placeReverse);
            _currentObject._objectSlot = this;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        _currentObject=null;
    }

    public Vial CurrentObject
    {
        get => (Vial)_currentObject;
        set => _currentObject = value;
    }
}