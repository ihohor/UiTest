using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TimeToAddLiveView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Text _timerTextWin;

        private const string Full = "Full";
        
        public void UpdateView(float currentTime)
        {
            float minutesWin = Mathf.FloorToInt(currentTime / 60);
            float secondsWin = Mathf.FloorToInt(currentTime % 60);
            _timerTextWin.text = $"{minutesWin:00}:{secondsWin:00}";

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            _timerText.text = $"{minutes:00}:{seconds:00}";
        }

        public void SetFull()
        {
            _timerText.text = Full;
            _timerTextWin.text = string.Empty;
        }
    }
}