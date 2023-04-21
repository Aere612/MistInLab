using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Type", menuName = "ScriptableObjects/IngradientsSO")]
public class IngradientsSO : ScriptableObject
{
    public Ingradient Type;
    public Material Material;
}
