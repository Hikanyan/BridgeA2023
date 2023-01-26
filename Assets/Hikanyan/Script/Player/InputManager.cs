using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Hikanyan.Core;
using Hikanyan.Runner;

namespace Hikanyan.Gameplay
{
    public class InputManager : SingletonBehaviour<InputManager>
    {
        [SerializeField] List<GameObject> _blockPrefabs = new();
        private List<InputInterface> _blocksIF = new();

        protected override void OnAwake()
        {
            foreach (GameObject block in _blockPrefabs)
            {
                InputInterface IF = block.GetComponent<InputInterface>();
                if (IF != null)
                {
                    _blocksIF.Add(IF);
                }
                else
                {
                    Debug.LogError("ブロックのインターフェースの取得に失敗しました");
                }
            }

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            { //Dが押された時呼び出す
                BlockPress(0);
            }

            if (Input.GetKeyDown(KeyCode.F))
            { //Fが押された時呼び出す
                BlockPress(1);
            }

            if (Input.GetKeyDown(KeyCode.J))
            { //Jが押された時呼び出す
                BlockPress(2);
            }

            if (Input.GetKeyDown(KeyCode.K))
            { //Kが押された時呼び出す
                BlockPress(3);
            }

            if (Input.GetKeyUp(KeyCode.D))
            { //Dが押された時呼び出す
                BlockRelease(0);
            }

            if (Input.GetKeyUp(KeyCode.F))
            { //Fが押された時呼び出す
                BlockRelease(1);
            }

            if (Input.GetKeyUp(KeyCode.J))
            { //Jが押された時呼び出す
                BlockRelease(2);
            }

            if (Input.GetKeyUp(KeyCode.K))
            { //Kが押された時呼び出す
                BlockRelease(3);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        /// <summary>
        /// 押されたキーに対応するブロックにインターフェースで実行
        /// </summary>
        /// <param name="block"></param>
        public void BlockPress(int block)
        {
            _blocksIF[block].Press();
            NotesManager.Instance.BlockPress(block);
        }

        /// <summary>
        /// 押されたキーに対応するブロックにインターフェースで実行
        /// </summary>
        /// <param name="block"></param>
        public void BlockRelease(int block)
        {
            NotesManager.Instance.BlockRelease(block);
        }
    }
}