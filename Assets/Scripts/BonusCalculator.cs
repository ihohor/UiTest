using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BonusCalculator : MonoBehaviour
{
    [SerializeField] private Text _dailyBonusText;

    private int _day;
    private int _month;
    private int _dayOfSeason;

    private void Start()
    {
         _day = DateTime.Today.Day;
         _month = DateTime.Today.Month;

        switch (_month)
        {
            case 1:
            case 4:
                _dayOfSeason = _day + 31;
                break;
            case 2:
                _dayOfSeason = _day + 62;
                break;
            case 3:
            case 6:
            case 9:
            case 12:
                _dayOfSeason = _day;
                break;
            case 5:
            case 8:
            case 11:
                _dayOfSeason = _day + 61;
                break;
            case 7:
            case 10:
                _dayOfSeason = _day + 30;
                break;
        }

        float[] finalBonus = new float[_dayOfSeason];

        for(int i = 0; i < finalBonus.Length; i++)
        {
            if (i == 0)
                finalBonus[0] = 2;
            else if (i == 1)
                finalBonus[1] = 3;
            else
                finalBonus[i] = finalBonus[i - 2] + finalBonus[i-1] * 0.6f;
        }

        int sum = Convert.ToInt32(finalBonus.Sum());

        _dailyBonusText.text = sum.ToString();
    }
}
