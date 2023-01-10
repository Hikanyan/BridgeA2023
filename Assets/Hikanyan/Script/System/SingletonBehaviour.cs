using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hikanyan.Core
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;


        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Type t = typeof(T);
                    _instance = (T)FindObjectOfType(t);

                    if (_instance == null)
                    {
                        Debug.LogError($"{t}をアタッチしているGameObjectがありません");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            OnAwake();
            ChackIns();
        }


        /// <summary>
        /// 継承先でAwakeが必要な場合はこれを呼ぶ
        /// </summary>
        protected virtual void OnAwake() { }

        protected void ChackIns()
        {
            if (_instance == null)
            {
                //キャストの意味を理解する。T型にキャストしている
                _instance = this as T;
            }
            else if (Instance == this)
            {
                return;
            }
            else if (Instance != this)
            {
                //すでにあった時は何もせずに消える
                Destroy(this);
            }
        }

    }
}