using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hikanyan.Gameplay
{
    public class OnClickSceneMove : MonoBehaviour
    {
        [SerializeField,Tooltip("�ړ��������V�[���̖��O�����")]
        readonly string _sceneName;
        [SerializeField,Tooltip("SceneController���Q��")]
        readonly SceneController _SceneController;
        private void Awake()
        {
            GetComponent<Button>()?.onClick.AddListener(OnClickButton);
        }

        void OnClickButton()
        {
            Debug.Log($"�{�^����������܂���{_sceneName}�Ɉړ����܂��B");
            _SceneController.LoadNewScene(_sceneName);
        }

    }
}