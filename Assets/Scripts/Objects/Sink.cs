using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;

    public void Interaction()
    {
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            if (_vial.baseIngradiant != Ingradiant.Empty)
            {
                _vial.baseIngradiant = Ingradiant.Empty;
                _vial.sideIngradiant = Ingradiant.Empty;
                return;
            }
            Destroy(_playerHandSo.CurrentObject.gameObject);
        }
        
        if (_playerHandSo.CurrentObject != null)
        {
            Destroy(_playerHandSo.CurrentObject.gameObject);
        }
    }
}