using Hikanyan.Core;
using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Hikanyan.Gameplay
{
    public class OnClickSceneMove : MonoBehaviour
    {
        [SerializeField,Tooltip("�ړ��������V�[���̖��O�����")]
        string _sceneName;
        
        private void Awake()
        {
            GetComponent<Button>()?.onClick.AddListener(OnClickButton);
        }

        void OnClickButton()
        {
            Debug.Log($"�{�^����������܂���{_sceneName}�Ɉړ����܂��B");
            SceneManager.LoadScene(_sceneName);
        }

    }
}