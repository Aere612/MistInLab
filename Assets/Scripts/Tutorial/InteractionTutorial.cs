using UnityEngine;
using DG.Tweening;

public class InteractionTutorial : MonoBehaviour,IInteractable
{
    [SerializeField] private PlayerHandSo playerHandSo;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private DropTutorial dropTutorial;

    private void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0.1f, 1));
        sequence.Append(transform.DOScale(0.1f, 0.1f));
        sequence.Append(transform.DOScale(0.086f, 1));
        sequence.Append(transform.DOScale(0.086f, 0.1f));
        sequence.SetLoops(-1);
    }
    private void End()
    {
        dropTutorial.EnableSprite();
        Destroy(gameObject);
    }
    private void Vanish()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(new Color(1, 1, 1, 0), 1f));
        sequence.OnComplete(End);
    }
    public void Interaction()
    {
        if (playerHandSo.CurrentObject.TryGetComponent<Key>(out _)) Vanish();
    }
}
