using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hikanyan.Runner;

public class OnClickSceneMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動したいシーンの名前を入力")]
    readonly string _sceneName;
    [SerializeField, Tooltip("SceneControllerを参照")]
    readonly SceneController _SceneController;
    private void Awake()
    {
        GetComponent<Button>()?.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        Debug.Log($"ボタンが押されました{_sceneName}に移動します。");
        _SceneController.LoadNewScene(_sceneName);
    }

}

