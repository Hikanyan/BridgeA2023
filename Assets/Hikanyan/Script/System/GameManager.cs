using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Hikanyan.Core
{
    //���ԊǗ�
    //�I�[�f�B�I
    //�p�[�e�B�N��
    //UI
    //�X�R�A
    //
    public class GameManager : SingletonBehaviour<GameManager>
    {
        

        void GameStart()
        {
            GameTimer.Instance.TimerStart();
        }
        void GameEnd()
        {
            
        }
        
    }
}