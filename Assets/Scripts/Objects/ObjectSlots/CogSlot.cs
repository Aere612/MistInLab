using UnityEngine;

public class CogSlot : BaseObjectSlot
{
    [SerializeField] private AudioSource cogInsertSfx;
    [SerializeField] private bool turnRight;

    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Cog>(out var _cog) || _currentObject != null) return;
        cogInsertSfx.Play();
        CurrentObject = _cog;
        PlaceTheObject(_currentObject.gameObject, false);
        _currentObject._objectSlot = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gear"))
        {
            if (other.gameObject == null) return;
            if (!other.gameObject.TryGetComponent<Cog>(out var _cog) || _currentObject != null) return;
            cogInsertSfx.Play();
            CurrentObject = _cog;
            PlaceTheObject(_currentObject.gameObject, false);
            _currentObject._objectSlot = this;
        }
        
    }

    public Cog CurrentObject
    {
        get => (Cog)_currentObject;
        set
        {
            _currentObject = value;
            if (_currentObject.TryGetComponent<CogAnimation>(out var _cogAnimation))
            {
                _cogAnimation.turnRight = turnRight;
            }
        }
    }
}