using System;
using System.Security.Cryptography;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField] internal BaseObjectSlot _objectSlot;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<LitterBin>(out var sink))
        {
            Destroy(this.gameObject,0.1f);
        }
    }
}
