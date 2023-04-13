using UnityEngine;
using DG.Tweening;

public class LookTutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MoveTutorial moveTutorial;
    
    private void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveX(-9.25f, 1));
        sequence.Append(transform.DOLocalMoveX(-9.25f, 0.1f));
        sequence.Append(transform.DOLocalMoveX(-8.75f, 1));
        sequence.Append(transform.DOLocalMoveX(-8.75f, 0.1f));
        sequence.SetLoops(-1);
    }
    
    private void Vanish()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOColor(new Color(1, 1, 1, 0), 2f));
        sequence.OnComplete(End);
    }

    private void End()
    {
        moveTutorial.gameObject.SetActive(true);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vanish();
        }
    }
}
