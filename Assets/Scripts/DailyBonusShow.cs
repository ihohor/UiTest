using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusShow : MonoBehaviour
{
    [SerializeField] private RectTransform _dailyBonusWindow;
    [SerializeField] private Image _firstPanelAlpha;
    [SerializeField] private Button _claimButton;
    [SerializeField] private GameObject _firstPanel;

    private void OnEnable()
    {
        _claimButton.onClick.AddListener(ClaimBonus) ;
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
        _dailyBonusWindow.DOAnchorPos(new Vector3(0, -2000, 0), 1);
        _firstPanel.SetActive(false);
    }
}
