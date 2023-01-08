using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Core
{
    /// <summary>
    /// リアルタイムを用いた時間制御
    /// </summary>
    public class GameTimer : SingletonBehaviour<GameTimer>
    {
        float _startTime = 0;
        float _cacheTime = 0;
        float _pauseTime = 0;
        public float RealTime { get; private set; }

        public bool IsRunning { get; private set; }

        public void TimerStart()
        {
            IsRunning = true;
            _startTime = Time.realtimeSinceStartup;
        }

        public void TimerPause()
        {
            IsRunning = false;
            _pauseTime = Time.realtimeSinceStartup;
        }
        public void TimerUnPause()
        {
            IsRunning = true;
            _cacheTime = Time.realtimeSinceStartup - _pauseTime;
        }
        public void TimerEnd()
        {
            IsRunning = false;
            _startTime = 0;
        }

        void Update()
        {
            if (!IsRunning) return;

            RealTime = Time.realtimeSinceStartup - _startTime - _cacheTime;
            Debug.Log(RealTime);
        }
    }
}
