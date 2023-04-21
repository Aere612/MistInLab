using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngradientMaterials", menuName = "ScriptableObjects/IngradiantMaterials")]
public class IngradiantMaterials : ScriptableObject
{
    [SerializeField] private List<Material> _materials;

    public Material GetMaterial(Ingradient ıngradient)
    {
        return ıngradient switch
        {
            Ingradient.Empty => _materials[0],
            Ingradient.Blue => _materials[1],
            Ingradient.Yellow => _materials[2],
            Ingradient.Red => _materials[3],
            Ingradient.Orange => _materials[4],
            Ingradient.Purple => _materials[5],
            Ingradient.LightBlue => _materials[6],
            Ingradient.BoldYellow => _materials[7],
            Ingradient.Acid => _materials[8],
            Ingradient.Green => _materials[9],
            _ => null
        };
    }
}