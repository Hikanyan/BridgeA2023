using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Hikanyan.Core
{
    //時間管理
    //オーディオ
    //パーティクル
    //UI
    //スコア
    //
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] int _Score;
        void GameStart()
        {
            GameTimer.Instance.TimerStart();
            //CRIAudioManager.Instance.
        }
        void GameEnd()
        {
            
        }
        
    }
}