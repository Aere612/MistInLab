using UnityEngine;
using DG.Tweening;

public class PickUpTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InteractionTutorial interactionTutorial;
    private void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(1f, 1));
        sequence.Append(transform.DOLocalMoveY(1f, 0.1f));
        sequence.Append(transform.DOLocalMoveY(0f, 1));
        sequence.Append(transform.DOLocalMoveY(0f, 0.1f));
        sequence.SetLoops(-1);
    }
    public void Vanish()
    {
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