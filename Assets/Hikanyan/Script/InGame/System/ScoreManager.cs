using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hikanyan.JudgeData;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
        [SerializeField, Tooltip("ScoreText")]
    TextMeshProUGUI _scoreText;

    [SerializeField, Tooltip("ResultRankText")]
    TextMeshProUGUI _resultRankText;
    [SerializeField, Tooltip("ResultScoreText")]
    TextMeshProUGUI _resultScoreText;
    [SerializeField, Tooltip("ResultJudgeText")]
    TextMeshProUGUI _resultJudgeText;

    [Header("ComboText")]
    [SerializeField] TextMeshProUGUI _comboText;


    [HideInInspector] public int sum = 0;
    [HideInInspector] public int combo = 0;

    private int _maxCombo = 0;

    public int MaxScore;
    public int SingleScore;
    public int Score = 0;
    public int NotesNum;
    public float ClearPercent;

    public JudgeScores JudgeScores;

    protected override void OnAwake()
    {
        _comboText.gameObject.SetActive(false);
    }
    private void Start()
    {
        JudgeScores.PurePerfect = 0;
        JudgeScores.Great = 0;
        JudgeScores.Good = 0;
        JudgeScores.Bad = 0;
        JudgeScores.Miss = 0;
        _scoreText.text = $"0";
    }
    

    public void SetMaxScore()
    {
        Debug.Log(NotesNum);
        MaxScore = 10000000 + NotesNum;
        SingleScore = MaxScore / NotesNum;
    }
    public void AddScore(Judges judge)
    {
        float scorePercent = 1.0f;
        switch (judge)
        {
            case Judges.PurePerfect:
                scorePercent = 1.0f;
                break;
            case Judges.Perfect:
                scorePercent = 0.9f;
                break;
            case Judges.Great:
                scorePercent = 0.8f;
                break;
            case Judges.Good:
                scorePercent = 0.5f;
                break;
            case Judges.Bad:
                scorePercent = 0.3f;
                break;
            case Judges.Miss:
                scorePercent = 0.0f;
                break;
            default:
                break;
        }
        //Ø‚èŽÌ‚Ä
        Score += Mathf.FloorToInt(scorePercent * SingleScore);
        _scoreText.text = $"{Score}";
    }

    string GetRank()
    {
        ClearPercent = (float)Score / MaxScore;
        if (JudgeScores.PurePerfect >= NotesNum) return "APP";
        if (JudgeScores.Perfect + JudgeScores.PurePerfect >= NotesNum) return "AP";
        if (ClearPercent >= 1.00f) return "EX";
        if (ClearPercent >= 0.97f) return "S";
        if (ClearPercent >= 0.94f) return "A";
        if (ClearPercent >= 0.80f) return "B";
        if (ClearPercent >= 0.50f) return "C";
        return "D";
    }
    public void Combo(bool isCombo)
    {
        if (isCombo)
        {
            combo++;
            if (combo < 2) return;

            _comboText.text = $"Combo {combo}";
            if (combo == 2)
            {
                _comboText.gameObject.SetActive(true);
            }
            if (combo > _maxCombo)
            {
                _maxCombo = combo;
            }
        }
        else
        {
            combo = 0;
            _comboText.gameObject.SetActive(false);
        }
    }
    public ResultDatas GetResultData()
    {
        ResultDatas resultDatas = new ResultDatas();
        resultDatas.Rank = GetRank();
        resultDatas.ClearPercent = ClearPercent;
        resultDatas.Score = Score;
        resultDatas._judgeScores = JudgeScores;
        resultDatas._maxCombo = _maxCombo;
        return resultDatas;
    }
}

public struct ResultDatas
{
    public JudgeScores _judgeScores;
    public int _maxCombo;
    public int Score;
    public float ClearPercent;
    public string MusicName;
    public string Rank;
}
}