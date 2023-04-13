using UnityEngine;
using DG.Tweening;

public class MoveTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private Key key;
    private void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(2f, 1));
        sequence.Append(transform.DOLocalMoveY(2f, 0.1f));
        sequence.Append(transform.DOLocalMoveY(1.90f, 1));
        sequence.Append(transform.DOLocalMoveY(1.90f, 0.1f));
        sequence.SetLoops(-1);
    }
    private void Vanish()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(new Color(1, 1, 1, 0), 2f));
        sequence.Join(spriteRenderer2.DOColor(new Color(1, 1, 1, 0), 2f));
        sequence.OnComplete(End);
    }
    private void End()
    {
        key.gameObject.SetActive(true);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            Vanish();
        }
    }
}