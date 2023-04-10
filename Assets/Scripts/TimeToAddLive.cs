using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Lives))]
[RequireComponent(typeof(TimeToAddLiveView))]
public class TimeToAddLive : MonoBehaviour
{
    [SerializeField] private float _timeToIncreaseLive;

    private Lives _lives;
    private TimeToAddLiveView _view;
    
    private float _currentTime;

    private void Awake()
    {
        _lives = GetComponent<Lives>();
        _view = GetComponent<TimeToAddLiveView>();
    }

    private void Start()
    {
        _currentTime = _timeToIncreaseLive;
        _view.UpdateView(_currentTime);
    }

    private void OnEnable()
    {
        _lives.LivesIsFull += StopTimer;
        _lives.LiveLargerOfMinAndLessOfMax += ResetTimer;
        _lives.LivesChanged += ResetTimer;
        _lives.ZeroLives += ResetTimer;
    }

    private void OnDisable()
    {
        _lives.LivesIsFull -= StopTimer;
        _lives.LiveLargerOfMinAndLessOfMax -= ResetTimer;
        _lives.LivesChanged -= ResetTimer;
        _lives.ZeroLives -= ResetTimer;
    }

    private void Update()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            _view.UpdateView(_currentTime);

            if (_currentTime <= 0)
            {
                _view.UpdateView(_currentTime);
                _lives.TryIncreaseLive();
            }
        }
    }

    private void StopTimer()
    {
        _currentTime = 0;
        _view.SetFull();
    }

    private void ResetTimer()
    {
        _currentTime = _timeToIncreaseLive;
        _view.UpdateView(_currentTime);
    }
}