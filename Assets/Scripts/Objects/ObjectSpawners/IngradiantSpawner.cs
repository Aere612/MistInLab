using System;
using UnityEngine;

public class IngradiantSpawner : MonoBehaviour, IInteractable
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
        
        if (_vial.BaseIngradiant != _ingradientTypes.Empty)
        {
            if (_vial.SideIngradiant == _ingradientTypes.Empty)
            {
                _vial.SideIngradiant = _ingradient;
            }
            return;
        }

        _vial.BaseIngradiant = _ingradient;
    }

    public bool IsAvailableToCollect { get; set; } = true;
}