using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private GameObject credits;
    [SerializeField] private List<GameObject> newspapers;
    [SerializeField] private int newspaperCounter;
    private bool isAvaibleToDisplay;

    private void Start()
    {
        newspaperCounter = 0;
        isAvaibleToDisplay = false;

        blackScreen.DOColor(Color.black, 2).OnComplete(() =>
        {
            isAvaibleToDisplay = true;
            NewspaperDisplayer();
        });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NewspaperDisplayer();   
        }
    }

    public void NewspaperDisplayer()
    {
        if (!isAvaibleToDisplay) return;
        if (newspaperCounter > 0)
            newspapers[newspaperCounter - 1].GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 2);
        if (newspaperCounter+1 > newspapers.Count )
        {
            CreditsDisplayer();
            return;
        }
        isAvaibleToDisplay = false;
        newspapers[newspaperCounter].transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360);
        newspapers[newspaperCounter].transform.DOScale(new Vector3(0.75f, 0.75f, 0.75f), 2f)
            .OnComplete(() => { isAvaibleToDisplay = true; });
        newspaperCounter++;
    }

    private void CreditsDisplayer()
    {
        credits.transform.DOMoveY(2000, 20).SetEase(Ease.Linear).OnComplete(()=>SceneManager.LoadScene("MainMenu"));
    }
}