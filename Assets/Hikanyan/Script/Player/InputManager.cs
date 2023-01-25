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
                    Debug.LogError("�u���b�N�̃C���^�[�t�F�[�X�̎擾�Ɏ��s���܂���");
                }
            }

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            { //D�������ꂽ���Ăяo��
                BlockPress(0);
            }

            if (Input.GetKeyDown(KeyCode.F))
            { //F�������ꂽ���Ăяo��
                BlockPress(1);
            }

            if (Input.GetKeyDown(KeyCode.J))
            { //J�������ꂽ���Ăяo��
                BlockPress(2);
            }

            if (Input.GetKeyDown(KeyCode.K))
            { //K�������ꂽ���Ăяo��
                BlockPress(3);
            }

            if (Input.GetKeyUp(KeyCode.D))
            { //D�������ꂽ���Ăяo��
                BlockRelease(0);
            }

            if (Input.GetKeyUp(KeyCode.F))
            { //F�������ꂽ���Ăяo��
                BlockRelease(1);
            }

            if (Input.GetKeyUp(KeyCode.J))
            { //J�������ꂽ���Ăяo��
                BlockRelease(2);
            }

            if (Input.GetKeyUp(KeyCode.K))
            { //K�������ꂽ���Ăяo��
                BlockRelease(3);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        /// <summary>
        /// �����ꂽ�L�[�ɑΉ�����u���b�N�ɃC���^�[�t�F�[�X�Ŏ��s
        /// </summary>
        /// <param name="block"></param>
        public void BlockPress(int block)
        {
            _blocksIF[block].Press();
            NotesManager.Instance.BlockPress(block);
        }

        /// <summary>
        /// �����ꂽ�L�[�ɑΉ�����u���b�N�ɃC���^�[�t�F�[�X�Ŏ��s
        /// </summary>
        /// <param name="block"></param>
        public void BlockRelease(int block)
        {
            NotesManager.Instance.BlockRelease(block);
        }
    }
}