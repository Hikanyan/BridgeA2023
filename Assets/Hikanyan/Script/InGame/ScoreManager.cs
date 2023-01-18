using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hikanyan.JudgeData;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField,Tooltip("ScoreText")]
    TextMeshProUGUI _scoreText;

    public int MaxScore;
    public int SingleScore;
    public int Score = 0;
    public int NotesNum;

    public JudgeScores JudgeScores;

    private void Awake()
    {
        
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
        //êÿÇËéÃÇƒ
        Score += Mathf.FloorToInt(scorePercent * SingleScore);
        _scoreText.text = $"{Score}";
    }
}
