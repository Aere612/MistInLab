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
    
    
    public void Interaction()
    {
        generatorStartSfx.Play();
        backgroundSfx.Play();
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
        Destroy(gameObject);
    }
}
