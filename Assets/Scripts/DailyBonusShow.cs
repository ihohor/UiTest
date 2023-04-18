using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusShow : MonoBehaviour
{
    [SerializeField] private RectTransform _dailyBonusWindow;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Image _firstPanel;

    private const float PanelMaxFade = 0.5f;
    private const float PanelMinFade = 0f;
    private const float PanelFadeDuration = 1f;
    private const float WindowMoveDuration = 1f;

    private readonly Vector3 _windowDownPosition = new Vector3(0, -2200, 0);

    private void OnEnable()
    {
        _claimButton.onClick.AddListener(ClaimBonus);
    }
    private void OnDisable()
    {
        _claimButton.onClick.RemoveListener(ClaimBonus);
    }
    private void Start()
    {
        _dailyBonusWindow.DOAnchorPos(new Vector3(0, 0, 0), 1);
    }

    private void ClaimBonus()
    {
        _dailyBonusWindow.DOAnchorPos(_windowDownPosition, WindowMoveDuration);
        _firstPanel.raycastTarget = false;
        _firstPanel.DOFade(PanelMinFade, PanelFadeDuration)
            .SetEase(Ease.Flash);
    }
}
