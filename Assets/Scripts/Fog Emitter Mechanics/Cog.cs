using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHandSo playerHandSo;
    public void Interaction()
    {
        playerHandSo.PutInHand(gameObject);
    }
}
