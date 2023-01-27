using Hikanyan.Core;
using Hikanyan.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Hikanyan.Runner
{
    //時間管理
    //オーディオ
    //パーティクル
    //UI
    //スコア
    //ステージ
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField]
        AbstractGameEvent _winEvent;

        [SerializeField]
        AbstractGameEvent _loseEvent;


        [SerializeField]
        int _musicNumber;
        [SerializeField]
        AssetReferenceT<TextAsset> _musicJsonReference;
        [SerializeField]
        float _delayTime = 0.0f;
        [SerializeField]
        float _waitTime;

        [SerializeField]
        GameObject _setGameUI;
        [SerializeField]
        ResultUI _resultUI;
        public bool IsRunning => _isPlaying;
        bool _isPlaying;

        MusicData _musicData;
        protected override void Awake()
        {
            
        }

        void GameStart()
        {
            _isPlaying = true;
            if (_musicData != null)
            {
                _musicNumber = _musicData.MusicNumber;
                _musicJsonReference = _musicData.MusicJsonReference;
                _delayTime = _musicData.DelayTime;
            }
            
            GameTimer.Instance.TimerStart();
            CRIAudioManager.Instance.CRIPlayBGM(_musicNumber, _delayTime);
        }
        async void GameEnd()
        {
            GameTimer.Instance.TimerEnd();
            await Task.Delay(TimeSpan.FromSeconds(_waitTime));
            _resultUI.SetResultUI(ScoreManager.Instance.GetResultData());
        }
        public void Win()
        {
            _winEvent.Reset();
        }
        public void Lose()
        {
            _loseEvent.Reset();
        }

        public void MusicData(MusicData musicData)
        {
            _musicData = musicData;
        }
        void SetShowUI(bool isShow)
        {
            _setGameUI.SetActive(isShow);
        }


    }
}