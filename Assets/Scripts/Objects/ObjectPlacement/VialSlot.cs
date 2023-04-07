using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSlot : BaseObjectSlot
{
    [SerializeField] private GameObject machine;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial) && !isFull)
        {
            PlaceTheObject(_vial.gameObject);
            _vial.ObjectSlot = this;
        }
    }
}
