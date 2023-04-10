using UnityEngine;

[RequireComponent(typeof(Lives))]
public class AnimationSwitch : MonoBehaviour
{
    [SerializeField] private Animator _heart;
    [SerializeField] private Animator _greenButton;
    [SerializeField] private Animator _blueButton;
    
    private Lives _lives;

    private readonly int _blueNum = Animator.StringToHash("BlueNum");
    private readonly int _greenNum = Animator.StringToHash("GreenNum");
    private readonly int _heartNum = Animator.StringToHash("HeartNum");


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

    private void EmptyState() => ChangeAnimation(0);

    private void MiddleState() => ChangeAnimation(1);

    private void FullState() => ChangeAnimation(2);

    private void ChangeAnimation(int value)
    {
        _blueButton.SetInteger(_blueNum, value);
        _greenButton.SetInteger(_greenNum, value);
        _heart.SetInteger(_heartNum, value);
    }
}
