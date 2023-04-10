using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WindowPop : MonoBehaviour
{
    [SerializeField] private Image _darkPanel;
    [SerializeField] private RectTransform _window;
    [SerializeField] private Button _mainLivesButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _panelButton;

    private Button _darkPanelButton;
    
    private const float PanelMaxFade = 0.5f;
    private const float PanelMinFade = 0f;
    private const float PanelFadeDuration = 1f;
    private const float WindowMoveDuration = 1f;
    
    private readonly Vector3 _windowDownPosition = new Vector3(0, -2200, 0);

    private void Awake()
    {
        _darkPanelButton = _darkPanel.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _mainLivesButton.onClick.AddListener(GetUpWindow);
        _closeButton.onClick.AddListener(GetDownWindow);
        _panelButton.onClick.AddListener(GetDownWindow);
    }
    private void OnDisable()
    {
        _mainLivesButton.onClick.RemoveListener(GetUpWindow);
        _closeButton.onClick.RemoveListener(GetDownWindow);
        _panelButton.onClick.RemoveListener(GetDownWindow);
    }

    private void GetUpWindow()
    {
        _window.DOAnchorPos(Vector3.zero, WindowMoveDuration, true);
        _darkPanel.raycastTarget = true;
        _darkPanelButton.interactable = true;
        _darkPanel.DOFade(PanelMaxFade, PanelFadeDuration)
            .SetEase(Ease.Flash);
    }

    private void GetDownWindow()
    {
        _window.DOAnchorPos(_windowDownPosition, PanelFadeDuration, true);
        _darkPanel.raycastTarget = false;
        _darkPanelButton.interactable = false;
        _darkPanel.DOFade(PanelMinFade, PanelFadeDuration)
            .SetEase(Ease.Flash);
    }
}
