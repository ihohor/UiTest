using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LivesView))]
public class Lives : MonoBehaviour
{
    [SerializeField] private int _maxLives;
    
    [SerializeField] private Button _greenButton;
    [SerializeField] private Button _bluebutton;
    
    private LivesView _livesView;
    
    private int _currentLives;
    
    public event Action LivesIsFull;
    public event Action ZeroLives;
    public event Action LiveLargerOfMinAndLessOfMax;
    public event Action LivesChanged;

    private void Awake()
    {
        _livesView = GetComponent<LivesView>();
    }
    
    private void OnEnable()
    {
        _greenButton.onClick.AddListener(TryDecreaseLive);
        _bluebutton.onClick.AddListener(SetMaxLives);
    }
    
    private void OnDisable()
    {
        _greenButton.onClick.RemoveListener(TryDecreaseLive);
        _bluebutton.onClick.RemoveListener(SetMaxLives);
    }

    private void Start()
    {
        _livesView.UpdateView(_currentLives);

        if (_currentLives <= 0)
        {
            _currentLives = 0;
            ZeroLives?.Invoke();
        }

        else if (_currentLives > 0 && _currentLives < _maxLives)
            LiveLargerOfMinAndLessOfMax?.Invoke();

        else if (_currentLives >= _maxLives)
        {
            _currentLives = _maxLives;
            LivesIsFull?.Invoke();
        }
    }
    
    public void TryIncreaseLive()
    {
        if (_currentLives < _maxLives)
        {
            if (_currentLives <= 0)
                LiveLargerOfMinAndLessOfMax?.Invoke();
            else
                LivesChanged?.Invoke();

            _currentLives++;
            _livesView.UpdateView(_currentLives);
            
            if (_currentLives >= _maxLives)
                LivesIsFull?.Invoke();
        }
    }
    private void TryDecreaseLive()
    {
        if (_currentLives > 0)
        {
            if (_currentLives >= _maxLives)
                LiveLargerOfMinAndLessOfMax?.Invoke();
            else
                LivesChanged?.Invoke();
            
            _currentLives--;
            _livesView.UpdateView(_currentLives);
            
            if (_currentLives <= 0)
                ZeroLives?.Invoke();
        }
    }

    public void SetMaxLives()
    {
        _currentLives = _maxLives;
        _livesView.UpdateView(_currentLives);
        LivesIsFull?.Invoke();
    }
}
