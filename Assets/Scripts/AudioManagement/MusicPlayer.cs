using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip electronicCinematic;
    [SerializeField] private AudioClip serverError;
    [SerializeField] private AudioClip sadHorror;
    [SerializeField] private AudioClip darkAmbient;
    [SerializeField] private AudioClip suspense;
    [SerializeField] private AudioClip toccata;
    [SerializeField] private CountDown countDown;
    [SerializeField] private AudioSource audioSource;

    public void Check()
    {
        switch (countDown.TimeLeft)
        {
            case 899://electronicCinematic
                audioSource.clip = electronicCinematic;
                audioSource.Play();
                break;
            case 850://serverError
                audioSource.clip = serverError;
                audioSource.Play();
                break;
            case 770://sadHorrorMusic
                audioSource.clip = sadHorror;
                audioSource.Play();
                break;
            case 700://darkAmbient
                audioSource.clip = darkAmbient;
                audioSource.Play();
                break;
            case 500://suspense
                audioSource.clip = suspense;
                audioSource.Play();
                break;
            case 410://toccata
                audioSource.clip = toccata;
                audioSource.Play();
                break;
        }
    }
}
