using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WindowPop : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _panelAlpha;
    [SerializeField] private RectTransform _window;
    [SerializeField] private Button _mainLivesButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _panelButton;

    private void OnEnable()
    {
        _mainLivesButton.onClick.AddListener(PopWindow);
        _closeButton.onClick.AddListener(GetDownWindow);
        _panelButton.onClick.AddListener(GetDownWindow);
    }
    private void OnDisable()
    {
        _mainLivesButton.onClick.RemoveListener(PopWindow);
        _closeButton.onClick.RemoveListener(GetDownWindow);
        _panelButton.onClick.RemoveListener(GetDownWindow);
    }

    private void PopWindow()
    {
        _window.DOAnchorPos(new Vector3(0, 0, 0), 1, true);
        _panel.SetActive(true);
        _panelAlpha.DOFade(0.5f, 1);
    }

    private void GetDownWindow()
    {
        _window.DOAnchorPos(new Vector3(0, -2200, 0), 1, true);
        _panel.SetActive(false);
    }
}
