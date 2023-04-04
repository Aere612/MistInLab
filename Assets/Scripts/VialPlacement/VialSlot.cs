using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSlot : MonoBehaviour,IInteractable
{
    [SerializeField] private PlayerHandSo _playerHandSo;
    public void Interaction()
    {
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out Vial _vial))
        {
            
        }
    }
}
