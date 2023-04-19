using UnityEngine;
using DG.Tweening;

public class Flicker : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private Light light3;
    [SerializeField] private Light light4;
    [SerializeField] private Light light5;
    [SerializeField] private Light light6;
    [SerializeField] private Light light7;
    [SerializeField] private Light light8;
    [SerializeField] private JanitorRoomDoor janitorRoomDoor;
    [SerializeField] private GameEvent onGameLoseEvent;


    public void Attack()
    {
        FlickerLights( light1);
        FlickerLights( light2);
        FlickerLights( light3);
        FlickerLights( light4);
        FlickerLights( light5);
        FlickerLights( light6);
        FlickerLights( light7);
        FlickerLights( light8, true);
    }

    private void SafetyCheck()
    {
        if (janitorRoomDoor.DoorLocked)
        {
            light1.DOIntensity(0.5f, 2f);
            light2.DOIntensity(0.5f, 2f);
            light3.DOIntensity(0.5f, 2f);
            light4.DOIntensity(0.5f, 2f);
            light5.DOIntensity(0.5f, 2f);
            light6.DOIntensity(0.5f, 2f);
            light7.DOIntensity(0.5f, 2f);
            light8.DOIntensity(0.5f, 2f);
            return;
        }
        onGameLoseEvent.Raise();
    }

    private void FlickerLights( Light targetLight, bool activator = false)
    {
        var targetSequence = DOTween.Sequence();
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.3f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.3f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.5f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.4f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.2f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.1f, 0.1f));
        targetSequence.Append(targetLight.DOIntensity(0.35f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.25f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(0.5f, 0.2f));
        targetSequence.Append(targetLight.DOIntensity(0.25f, 0.3f));
        targetSequence.Append(targetLight.DOIntensity(0.0f, 5.0f));
        if(activator)targetSequence.OnComplete(SafetyCheck);
    }
}