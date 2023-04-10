using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<IDeletable>(out _))
        {
            Destroy(collision.collider.gameObject,0.5f);
        }
    }
}
