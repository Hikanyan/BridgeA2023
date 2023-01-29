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
        [SerializeField,Tooltip("移動したいシーンの名前を入力")]
        string _sceneName;
        
        private void Awake()
        {
            GetComponent<Button>()?.onClick.AddListener(OnClickButton);
        }

        void OnClickButton()
        {
            Debug.Log($"ボタンが押されました{_sceneName}に移動します。");
            SceneManager.LoadScene(_sceneName);
        }

    }
}