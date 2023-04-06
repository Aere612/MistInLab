using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSlot : BaseObjectSlot
{
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            PlaceTheObject(_vial.gameObject);
        }
    }
}
