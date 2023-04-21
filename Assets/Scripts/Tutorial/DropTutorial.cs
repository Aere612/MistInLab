using DG.Tweening;
using UnityEngine;

public class DropTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool interactionTutorialComplete;
    [SerializeField] private SkipTutorial skipTutorial;

    public void EnableSprite()
    {
        spriteRenderer.enabled = true;
        interactionTutorialComplete = true;
    }

    private void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(5.3f, 1));
        sequence.Append(transform.DOScale(5.3f, 0.1f));
        sequence.Append(transform.DOScale(4.7f, 1));
        sequence.Append(transform.DOScale(4.7f, 0.1f));
        sequence.SetLoops(-1);
    }
    private void End()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && interactionTutorialComplete) Vanish();
    }

    private void Vanish()
    {
        skipTutorial.Vanish();
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(new Color(1, 1, 1, 0), 1f));
        sequence.OnComplete(End);
    }
}