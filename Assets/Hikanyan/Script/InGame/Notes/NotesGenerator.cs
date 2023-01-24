using Hikanyan.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Hikanyan.Gameplay
{
    /// <summary>
    /// [TODO]
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
        [SerializeField] GameObject _tapNotesObject;
        /// <summary>
        /// �m�[�c�̃X�s�[�h
        /// </summary>
        [SerializeField] float _notesSpeed;
        /// <summary>
        /// �m�[�c�̕\������鉜�s��(���T�C�h)
        /// </summary>
        [SerializeField] float _blockHeight;


        private NotesData _inputJson;
        //�R���N�V�����̃C���X�^���X���Ɠ����ɗv�f��ǉ�
        private List<List<Notes>> _instanceNotesList = new List<List<Notes>>() { new(), new(), new(), new() };

        private void Start()
        {
            //�L���ɂ��ꂽ��Json�t�@�C����ǂݍ��݁A���W���v�Z���Ĕz�u����
            //�v���C���[�ݒ�����[�h
        }
        public async Task StartLoad(AssetReferenceT<TextAsset> jsonReference)
        {
            string inputString = "";
            //�������[�h
            //Json�̃��t�@�����X��TestAsset�ɕϊ�
            TextAsset data = await Addressables.LoadAssetAsync<TextAsset>(jsonReference).Task;
            inputString = data.text;


        }

        void GetNotesData()
        {

        }

    }
}