using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hikanyan.Core
{
    public class SceneController
    {
        Scene _lastScene;
        readonly Scene _neverUnloadScene;
        /// <summary>
        /// 全てのレベルに依存しないマネージャーをインスタンス化し、
        /// 決してアンロードしないシーン
        /// </summary>
        /// <param name="neverUnloadScene"></param>
        public SceneController(Scene neverUnloadScene)
        {
            _neverUnloadScene = neverUnloadScene;
            _lastScene = _neverUnloadScene;
        }
        public IEnumerator LoadScene(string scene)
        {
            //value パラメーターが null または空の文字列 ("") の場合は true。それ以外の場合は false。
            if (string.IsNullOrEmpty(scene))
            {
                throw new ArgumentException($"{nameof(scene)} is invalid!");
            }
            yield return UnloadLastScene();
            yield return LoadSceneAdditive(scene);
        }
        /// <summary>
        /// 指定された名前の新しい空のシーンを作成してロードし、他のシーンをアンロードします。
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerator LoadNewScene(string scene)
        {
            if (string.IsNullOrEmpty(scene))
            {
                throw new ArgumentException($"{nameof(scene)} is invalid!");
            }
            yield return UnloadLastScene();
            LoadNewSceneAdditive(scene);
        }
        /// <summary>
        /// 指定された名前で実行時に空の新しいシーンを作成します。
        /// </summary>
        /// <param name="sceneName"></param>
        void LoadNewSceneAdditive(string sceneName)
        {
            var scene = SceneManager.CreateScene(sceneName);
            SceneManager.SetActiveScene(scene);
            _lastScene = scene;
        }

        /// <summary>
        /// 最後にロードされたシーンをアンロードします
        /// </summary>
        public IEnumerator UnloadLastScene()
        {
            if (_lastScene != _neverUnloadScene)
            {
                yield return UnloadScene(_lastScene);
            }
        }
        /// <summary>
        /// 指定されたシーンに関連付けられたすべてのゲームオブジェクトを破棄し、シーンを削除します。
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        IEnumerator UnloadScene(Scene scene)
        {
            if (!_lastScene.IsValid())//これが有効なシーンじゃなかったら
            {
                yield break;
            }

            var asyncUnload = SceneManager.UnloadSceneAsync(scene);
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
        }
        //シーンをバックグラウンドで非同期にロードします。
        IEnumerator LoadSceneAdditive(string scenePath)
        {
            var asyncLoad = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            _lastScene = SceneManager.GetSceneByPath(scenePath);
            SceneManager.SetActiveScene(_lastScene);
        }
    }
}
