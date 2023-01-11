using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Gameplay
{
    /// <summary>
    /// �S�̂̃f�[�^
    /// </summary>
    [Serializable]
    public class NotesData
    {
        public TapNotesInput[] tapNotes;
        public HoldNotesInput[] holdNotes;
    }
    /// <summary>
    /// �^�b�v�m�[�c�̃f�[�^
    /// </summary>
    [Serializable]
    public class TapNotesInput
    {
        public int type;
        public float time;
        public int block;
    }
    /// <summary>
    /// �z�[���h�m�[�c�̃f�[�^
    /// </summary>
    [Serializable]
    public class HoldNotesInput
    {
        public int type;
        public float[] time;
        public int block;
    }


    public class NotesGenerator : MonoBehaviour
    {
        /// <summary>
        /// �ǂ̃��[���Ƀm�[�c�������Ă��邩
        /// </summary>
        public List<int> LaneNum = new();
        /// <summary>
        /// Notes�̎��
        /// </summary>
        public List<int> HoldType = new();
        /// <summary>
        /// �m�[�c��������ɏd�Ȃ鎞��
        /// </summary>
        public List<int> NotesTime = new();
        /// <summary>
        /// �m�[�c�̃I�u�W�F�N�g
        /// </summary>
        public List<GameObject> NotesObject = new();
        /// <summary>
        /// �^�b�v�m�[�c�̃v���n�u������
        /// </summary>
        [SerializeField]GameObject _tapNotesObject;
        /// <summary>
        /// �m�[�c�̃X�s�[�h
        /// </summary>
        [SerializeField]float _notesSpeed;
        /// <summary>
        /// �m�[�c�̕\������鉜�s��(���T�C�h)
        /// </summary>
        [SerializeField] float _blockHeight;

        private void Start()
        {
            //�v���C���[�ݒ�����[�h
            //
        }
       �@void StartLoad()
        {

        }

    }
}