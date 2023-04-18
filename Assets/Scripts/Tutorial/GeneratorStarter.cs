using UnityEngine;

public class GeneratorStarter : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject terminal1;
    [SerializeField] private GameObject barrier1;
    [SerializeField] private GameObject barrier2;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private Light light4;
    [SerializeField] private Light light5;
    [SerializeField] private Light light6;
    [SerializeField] private Light light7;
    [SerializeField] private Light light8;
    [SerializeField] private Counter counter;
    [SerializeField] private AudioSource generatorStartSfx;
    [SerializeField] private AudioSource backgroundSfx;
    [SerializeField] private AudioSource lightSfx1;
    [SerializeField] private AudioSource lightSfx2;
    [SerializeField] private AudioSource lightSfx3;
    [SerializeField] private AudioSource lightSfx4;
    
    
    public void Interaction()
    {
        backgroundSfx.Play();
        generatorStartSfx.Play();
        lightSfx1.Play();
        lightSfx2.Play();
        lightSfx3.Play();
        lightSfx4.Play();
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        light4.enabled = true;
        light5.enabled = true;
        light6.enabled = true;
        light7.enabled = true;
        light8.enabled = true;
        counter.enabled = true;
        Destroy(barrier1);
        Destroy(barrier2);
        Destroy(terminal1);
    }
}
