using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSlot : MonoBehaviour,IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    public void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            _playerHandSo.CurrentObject.transform.parent = null;
            _vial.transform.position = transform.position + new Vector3(0, (_vial.transform.lossyScale.y - transform.lossyScale.y)/2f, 0);
            _vial.transform.rotation = transform.rotation;
            _playerHandSo.CurrentObject = null;
        }
    }
}
