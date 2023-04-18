using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoLightCloser : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<PlayerMovement>(out _)) return;
        light1.enabled = false;
        light2.enabled = false;
        Destroy(gameObject);
    }
}