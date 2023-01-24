using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Hikanyan.Runner
{
    //���ԊǗ�
    //�I�[�f�B�I
    //�p�[�e�B�N��
    //UI
    //�X�R�A
    //�X�e�[�W
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] 
        AbstractGameEvent _winEvent;

        [SerializeField]
        AbstractGameEvent _loseEvent;

        public bool IsRunning => _isPlaying;
        bool _isPlaying;

        protected override void Awake()
        {
            
        }

        void GameStart()
        {
            GameTimer.Instance.TimerStart();
            //CRIAudioManager.Instance.
        }
        void GameEnd()
        {
            
        }
        public void Win()
        {
            _winEvent.Reset();
        }
        public void Lose()
        {
            _loseEvent.Reset();
        }
        
    }
}