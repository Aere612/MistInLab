using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerController : MonoBehaviour
{
    [SerializeField] private Mixer mixer;
    [SerializeField] private VialSlot slot;
    [SerializeField] internal int currentCountdown;
    [SerializeField] internal bool isCountdownStarted;

    public void CheckCountdown()
    {
        if (slot.currentVial == null)
        {
            isCountdownStarted = false;
            return;
        }
        
        if (!isCountdownStarted || slot.currentVial.baseIngradiant == Ingradiant.Empty ||
            slot.currentVial.sideIngradiant == Ingradiant.Empty) return;

        if (currentCountdown > 0)
            currentCountdown--;
        else
        {
            RunTheMixer();
            isCountdownStarted = false;
        }
    }

    private void RunTheMixer()
    {
        if (slot.currentVial == null) return;

        slot.currentVial.baseIngradiant =
            mixer.MixIngradiants(slot.currentVial.baseIngradiant, slot.currentVial.sideIngradiant);
        slot.currentVial.sideIngradiant = Ingradiant.Empty;
    }
}