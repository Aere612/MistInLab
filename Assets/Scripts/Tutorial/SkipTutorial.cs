using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class SkipTutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skipTutorialText;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GeneratorStarter generatorStarter;
    [SerializeField] private AutoLightCloser lightCloser1;
    [SerializeField] private AutoLightCloser lightCloser2;
    [SerializeField] private AutoLightCloser lightCloser3;
    [SerializeField] private Transform door1;
    [SerializeField] private Transform door2;
    [SerializeField] private Transform player;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Skip();
    }

    private void Skip()
    {
        characterController.enabled = false;
        player.position = new Vector3(-5.37900019f, 1.7f, 0.54400003f);
        characterController.enabled = true;
        door1.Rotate(new Vector3(0,90,0));
        door2.Rotate(new Vector3(0,-90,0));
        generatorStarter.Interaction();
        lightCloser1.DoAnim();
        lightCloser2.DoAnim();
        lightCloser3.DoAnim();
        light1.enabled=false;
        light2.enabled=false;
        Destroy(tutorial);
    }
    public void Vanish()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(skipTutorialText.DOColor(new Color(1, 1, 1, 0), 1f));
        sequence.OnComplete(()=>Destroy(gameObject));
    }
}
