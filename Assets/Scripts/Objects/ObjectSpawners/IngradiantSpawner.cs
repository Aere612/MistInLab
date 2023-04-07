using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngradiantSpawner : ObjectSpawner
{
    public override void Interaction()
    {
        if (_playerHandSo.CurrentObject == null) return;
        if (_playerHandSo.CurrentObject.TryGetComponent<Vial>(out var _vial))
        {
            if (_vial.hasBaseIngradiant)
            {
                Debug.Log("There is another ingrediant");
                return;
            }

            _vial.hasBaseIngradiant = true;
            Debug.Log("Base Ingradient ejected");
        }
        else
        {
            Debug.Log("Wrong object to put");
        }
    }
}