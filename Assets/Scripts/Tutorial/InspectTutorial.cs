using System;
using DG.Tweening;
using UnityEngine;

public class InspectTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private InteractionTutorial interactionTutorial;
    [SerializeField] private GameObject arrowOne;
    [SerializeField] private GameObject arrowTwo;
    [SerializeField] private GameObject arrowThree;
    [SerializeField] private GameObject arrowFour;
    private void Awake()
    {
        arrowOne.SetActive(true);
        arrowTwo.SetActive(true);
        arrowThree.SetActive(true);
        arrowFour.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.12f, 1));
        sequence.Append(transform.DOScale(0.12f, 0.1f));
        sequence.Append(transform.DOScale(0.1f, 1));
        sequence.Append(transform.DOScale(0.1f, 0.1f));
        sequence.SetLoops(-1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) Vanish();
    }

    private void Vanish()
    {
        spriteRenderer2.DOColor(new Color(1, 1, 1, 0), 1f);
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(new Color(1, 1, 1, 0), 1f));
        sequence.OnComplete(End);
    }
    private void End()
    {
        interactionTutorial.gameObject.SetActive(true);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
