using System;
using DG.Tweening;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Transform door1;
    [SerializeField] private Transform door2;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private Light light4;
    [SerializeField] private Light light5;
    [SerializeField] private Light light6;
    [SerializeField] private Light light7;
    [SerializeField] private Light light8;
    [SerializeField] private AudioSource backgroundSfx;
    [SerializeField] private AudioSource backgroundTurnOffSfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<PlayerMovement>(out _)) Play();
    }


    private void Play()
    {
        backgroundSfx.Stop();
        backgroundTurnOffSfx.Play();
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        light5.enabled = false;
        light6.enabled = false;
        light7.enabled = false;
        light8.enabled = false;
        door1.DORotate(new Vector3(0,  90, 0), 1f);
        door2.DORotate(new Vector3(0, -90, 0), 1f);
        Destroy(gameObject);
    }
}