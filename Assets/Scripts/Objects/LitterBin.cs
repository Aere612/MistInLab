using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Collider>().TryGetComponent<IDeletable>(out _))
        {
            Destroy(collision.GetComponent<Collider>().gameObject,0.5f);
        }
    }
}
