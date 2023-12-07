using System;
using UnityEngine;

public class IngradiantSpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    [SerializeField] private IngradientsSO _ingradient;
    [SerializeField] private IngradientTypes _ingradientTypes;
    [SerializeField] private AudioSource _pickUpSfx;
    public bool once=false;

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
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Vial"))
        {

            if (once==false)
            {
                Debug.Log("girdi");
                _pickUpSfx.Play();
                if (other == null) return;
                if (!other.TryGetComponent<Vial>(out var _vial)) return;
                Debug.Log(_vial.name);


                if (_vial.BaseIngradiant != _ingradientTypes.Empty)
                {
                    if (_vial.SideIngradiant == _ingradientTypes.Empty)
                    {
                        _vial.SideIngradiant = _ingradient;
                    }
                    return;
                }

                _vial.BaseIngradiant = _ingradient;
                once= true;
            }

        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vial"))
        {
            once = false;
        }
    }

    public bool IsAvailableToCollect { get; set; } = true;
}