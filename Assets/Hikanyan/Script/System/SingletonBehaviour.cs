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
                        Debug.LogError($"{t}���A�^�b�`���Ă���GameObject������܂���");
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
        /// �p�����Awake���K�v�ȏꍇ�͂�����Ă�
        /// </summary>
        protected virtual void OnAwake() { }

        protected void ChackIns()
        {
            if (_instance == null)
            {
                //�L���X�g�̈Ӗ��𗝉�����BT�^�ɃL���X�g���Ă���
                _instance = this as T;
            }
            else if (Instance == this)
            {
                return;
            }
            else if (Instance != this)
            {
                //���łɂ��������͉��������ɏ�����
                Destroy(this);
            }
        }

    }
}