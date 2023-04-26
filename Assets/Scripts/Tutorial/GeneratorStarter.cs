using UnityEngine;

public class GeneratorStarter : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject terminal1;
    [SerializeField] private GameObject barrier1;
    [SerializeField] private GameObject barrier2;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private Counter counter;
    [SerializeField] private AudioSource generatorStartSfx;
    [SerializeField] private AudioSource backgroundSfx;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private Light flashlight;
    

    
    public void Interaction()
    {
        generatorStartSfx.Play();
        backgroundSfx.Play();
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        counter.enabled = true;
        flashlight.enabled = true;
        Destroy(barrier1);
        Destroy(barrier2);
        Destroy(terminal1);
        Destroy(tutorial);
        Destroy(gameObject);
    }
}
