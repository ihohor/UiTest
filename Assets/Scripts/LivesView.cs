using UnityEngine;
using UnityEngine.UI;

public class LivesView : MonoBehaviour
{
    [SerializeField] private Text _livesText;
    [SerializeField] private Text _livesTextWin;

    public void UpdateView(int currentLives)
    {
        _livesText.text = currentLives.ToString();
        _livesTextWin.text = currentLives.ToString();
    }
}
