using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSlot : BaseObjectSlot
{
    [SerializeField] internal Vial currentVial;

    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial) && currentVial == null)
        {
            currentVial = _vial;
            PlaceTheObject(currentVial.gameObject);
            currentVial._vialSlot = this;
        }
    }
}