using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogSlot : BaseObjectSlot
{
    [SerializeField] internal Cog currentCog;
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Cog>(out var _cog) && currentCog == null)
        {
            currentCog = _cog;
            PlaceTheObject(_cog.gameObject);
            _cog._cogSlot = this;
        }
    }
}
