using System;
using UnityEngine;

public class IngradiantSpawner : MonoBehaviour, IInteractable, ICollactable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private IngradientsSO _ingradient;
    [SerializeField] private IngradientTypes _ingradientTypes;
    [SerializeField] private AudioSource _pickUpSfx;

    private void Awake()
    {
        IsAvailableToCollect = true;
    }

    public void Interaction()
    {
        _pickUpSfx.Play();
        if (_playerHandSo.CurrentObject == null) return;
        if (!_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial)) return;
        
        if (_vial.baseIngradiant != _ingradientTypes.Empty)
        {
            if (_vial.sideIngradiant == _ingradientTypes.Empty)
            {
                _vial.sideIngradiant = _ingradient;
            }
            return;
        }

        _vial.baseIngradiant = _ingradient;
    }

    public bool IsAvailableToCollect { get; set; }
}