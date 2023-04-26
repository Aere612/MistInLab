using UnityEngine;
using DG.Tweening;

public class Flicker : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private JanitorRoomDoor janitorRoomDoor;
    [SerializeField] private GameEvent onGameLoseEvent;
    [SerializeField] private AudioSource flickerSound;

    public void Attack()
    {
        FlickerLights( light1);
        FlickerLights( light2);
        FlickerLights( light3,true);
        flickerSound.Play();
    }

    private void SafetyCheck()
    {
        if (!janitorRoomDoor.DoorLocked)
        {
            onGameLoseEvent.Raise();
            return;
        }
        light1.DOIntensity(2f, 2f);
        light2.DOIntensity(2f, 2f);
        light3.DOIntensity(2f, 2f);
        flickerSound.Stop();
    }

    private void FlickerLights( Light targetLight, bool activator = false)
    {
        var targetSequence = DOTween.Sequence();
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.6f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.8f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.6f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(1.0f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.8f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.7f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.5f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(1.0f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 5.0f));
        if(activator)targetSequence.OnComplete(SafetyCheck);
    }
}