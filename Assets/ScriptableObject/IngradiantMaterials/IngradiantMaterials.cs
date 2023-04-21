using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngradientMaterials", menuName = "ScriptableObjects/IngradiantMaterials")]
public class IngradiantMaterials : ScriptableObject
{
    [SerializeField] private List<Material> _materials;

    public Material GetMaterial(Ingradiant ingradiant)
    {
        return ingradiant switch
        {
            Ingradiant.Empty => _materials[0],
            Ingradiant.Blue => _materials[1],
            Ingradiant.Yellow => _materials[2],
            Ingradiant.Red => _materials[3],
            Ingradiant.Orange => _materials[4],
            Ingradiant.Purple => _materials[5],
            Ingradiant.LightBlue => _materials[6],
            Ingradiant.BoldYellow => _materials[7],
            Ingradiant.Acid => _materials[8],
            Ingradiant.Green => _materials[9],
            _ => null
        };
    }
}