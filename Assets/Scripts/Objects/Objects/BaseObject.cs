using System;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField] internal BaseObjectSlot _objectSlot;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Sink>(out _))
        {
            Destroy(this.gameObject,0.1f);
        }
    }
}
