using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hikanyan.Core;
using System;

namespace Hikanyan.Runner
{
    //[Serializable]
    public class SequenceManager : SingletonBehaviour<SequenceManager>
    {
        [SerializeField,Tooltip("Singletonを使うManagerを入れる")]
        GameObject[] _preloadedAssets;
        [SerializeField,Tooltip("")]


        SceneController _sceneController;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _sceneController = new SceneController(SceneManager.GetActiveScene());
            InstantiatePreloadedAssets();
        }

        /// <summary>
        /// PreloadedAssetsを全てインスタンス化
        /// </summary>
        void InstantiatePreloadedAssets()
        {
            foreach (var asset in _preloadedAssets)
            {
                Instantiate(asset);
            }
        }
    }
}