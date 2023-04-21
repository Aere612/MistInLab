using UnityEngine;

public class AutoLightCloser : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private ParticleSystem particleSystem2;


    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent<PlayerMovement>(out _)) return;
        DoAnim();
    }

    public void DoAnim()
    {
        light1.enabled = false;
        light2.enabled = false;
        audioSource1.Play();
        audioSource2.Play();
        particleSystem.Play();
        particleSystem2.Play();
        Destroy(gameObject);
    }
}