using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField,Tooltip("ScoreText")]
    TextMeshProUGUI _scoreText;
}
