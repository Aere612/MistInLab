using System;
using DG.Tweening;
using UnityEngine;

public class InspectTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private InteractionTutorial interactionTutorial;
    [SerializeField] private GameObject magnify;
    private void Awake()
    {
        magnify.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.12f, 1));
        sequence.Append(transform.DOScale(0.12f, 0.1f));
        sequence.Append(transform.DOScale(0.1f, 1));
        sequence.Append(transform.DOScale(0.1f, 0.1f));
        sequence.SetLoops(-1);
        var sequence2 = DOTween.Sequence();
        sequence2.Append(magnify.transform.DOScale(0.05f, 1));
        sequence2.Append(magnify.transform.DOScale(0.05f, 0.1f));
        sequence2.Append(magnify.transform.DOScale(0.04f, 1));
        sequence2.Append(magnify.transform.DOScale(0.04f, 0.1f));
        sequence2.SetLoops(-1);
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
        Destroy(gameObject);
    }
}
