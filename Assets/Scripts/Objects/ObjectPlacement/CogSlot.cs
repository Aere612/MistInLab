using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSlot : BaseObjectSlot
{
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Cog>(out var _cog) && !isFull)
        {
            PlaceTheObject(_cog.gameObject);
            _cog.ObjectSlot = this;
        }
    }
}
