using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Lives))]
public class Animations : MonoBehaviour
{
    [SerializeField] private RectTransform _heart;
    [SerializeField] private RectTransform _greenButton;
    [SerializeField] private RectTransform _blueButton;

    private Lives _lives;

    private const float ChangeButtonDuration = 0.2f;
    
    private void Awake()
    {
        _lives = GetComponent<Lives>();
    }

    private void OnEnable()
    {
        _lives.LivesIsFull += FullState;
        _lives.LiveLargerOfMinAndLessOfMax += MiddleState;
        _lives.ZeroLives += EmptyState;
    }

    private void OnDisable()
    {
        _lives.LivesIsFull -= FullState;
        _lives.LiveLargerOfMinAndLessOfMax -= MiddleState;
        _lives.ZeroLives -= EmptyState;
    }

    private void FullState() => ChangeButtonsStates(new Vector2(120, 120), 
        new Vector3(0, -50, 0), new Vector2(100, 50), 
        new Vector3(0, -50, 0), Vector2.zero, new Vector3(0, -900, 0));

    private void MiddleState() => 
        ChangeButtonsStates(Vector2.zero, Vector3.zero,
        Vector2.zero, Vector3.zero,
        Vector2.zero, Vector3.zero);

    private void EmptyState() => ChangeButtonsStates(Vector2.zero, Vector3.zero, 
        new Vector2(100, 50), new Vector3(0, 150, 0),
        Vector2.zero, new Vector3(0, -1000, 0));
    
    private void ChangeButtonsStates(Vector2 heartSize, Vector3 heartPos, 
        Vector2 blueButtonSize, Vector3 blueButtonPos, Vector2 greenButtonSize, Vector3 greenButtonPos)
    {
        _heart.DOSizeDelta(heartSize, ChangeButtonDuration, true);
        _heart.DOAnchorPos(heartPos, ChangeButtonDuration, true);

        _blueButton.DOSizeDelta(blueButtonSize, ChangeButtonDuration, true);
        _blueButton.DOAnchorPos(blueButtonPos, ChangeButtonDuration, true);

        _greenButton.DOSizeDelta(greenButtonSize, ChangeButtonDuration, true);
        _greenButton.DOAnchorPos(greenButtonPos, ChangeButtonDuration, true);
    }
}
