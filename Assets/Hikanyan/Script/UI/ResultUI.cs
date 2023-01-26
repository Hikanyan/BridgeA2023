using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hikanyan.Core;

public class ResultUI
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _rankText;
    public void SetResultUI(ResultDatas resultDatas)
    {
        _scoreText.text = $"{ToScoreText(resultDatas.Score)}";
        _rankText.text = $"{resultDatas.Rank}";
    }
    string ToScoreText(int sccore)
    {
        string ans = sccore.ToString();
        for (int i = 2; i <= ans.Length; i++)
        {
            if (i % 4 == 0)
            {
                ans = ans.Insert(i - 3, "\'");
            }
        }
        return ans;
    }
}
