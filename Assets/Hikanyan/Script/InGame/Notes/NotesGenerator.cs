using Hikanyan.Core;
using Hikanyan.Runner;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AddressableAssets;
using static TreeEditor.TreeEditorHelper;

namespace Hikanyan.Gameplay
{
    /// <summary>
    /// [TODO]
    /// �S�̂̃f�[�^
    /// </summary>
    [Serializable]
    public class NotesData
    {
        public string name;
        public int maxBlock;
        public int BPM;
        public int offset;
        public TapNotesInput[] notes;
    }
    /// <summary>
    /// �^�b�v�m�[�c�̃f�[�^
    /// </summary>
    [Serializable]
    public class TapNotesInput
    {
        public int type;
        public int num;
        public int block;
        public int LPB;
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
        /// <summary>�m�[�c�̑��� </summary>
        public int NoteNum;
        /// <summary>���Ԗڂ̃��[���Ƀm�[�c�������Ă��邩 </summary>
        public List<int> LaneNum = new();
        /// <summary>Notes�̎�� </summary>
        public List<int> NoteType = new();
        /// <summary>�m�[�c��������Əd�Ȃ鎞�� </summary>
        public List<float> NotesTime = new();
        /// <summary>�m�[�c�̃I�u�W�F�N�g</summary>
        public List<GameObject> NotesObject = new();


        /// <summary>�Ȗ�</summary>
        public AssetReferenceT<TextAsset> _jsonMusic;//�Ȗ�������֐����쐬����B�ۑ�����Json�̖��O������
        /// <summary>�V���O���m�[�c�̃I�u�W�F�N�g</summary>
        [SerializeField] private GameObject _noteObject;//�m�[�c�̃v���n�u������
        /// <summary>�����O�m�[�c�̃I�u�W�F�N�g</summary>
        [SerializeField] private GameObject _noteLongObject;//�����O�m�[�c�̃v���n�u������
        /// <summary>�m�[�c�̃X�s�[�h</summary>
        [HideInInspector] public static float _notesSpeed = 5.0f;//�m�[�c�̃X�s�[�h
        /// <summary>�m�[�c������Ă���P�\ </summary>
        public float _notesOffset;//�m�[�c������Ă���x������(������)


        private NotesData _inputJson;
        //�R���N�V�����̃C���X�^���X���Ɠ����ɗv�f��ǉ�
        private List<List<Notes>> _instanceNotesList = new List<List<Notes>>() { new(), new(), new(), new() };

        private void Start()
        {
            //�L���ɂ��ꂽ��Json�t�@�C����ǂݍ��݁A���W���v�Z���Ĕz�u����
            //�v���C���[�ݒ�����[�h
        }
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_notesOffset);
            StartLoad(_jsonMusic);
        }
        public async Task StartLoad(AssetReferenceT<TextAsset> jsonReference)
        {
            string inputString = "";
            //�������[�h
            //Json�̃��t�@�����X��TestAsset�ɕϊ�
            TextAsset data = await Addressables.LoadAssetAsync<TextAsset>(jsonReference).Task;
            inputString = data.text;

            _inputJson = JsonUtility.FromJson<NotesData>(inputString);

            Generat();
            GameManager.Instance.GameStart();
        }

        void Generat()
        {
            for (int i = 0; i < _inputJson.notes.Length; i++)//�m�[�c�̈ʒu������z�u���Ă���
            {
                float syousetu = 60 / (_inputJson.BPM * (float)_inputJson.notes[i].LPB);                                      //�ꏬ�߂̒���
                float beatSec = syousetu * (float)_inputJson.notes[i].LPB;                                                   //�m�[�c�̒���
                float time = (beatSec * _inputJson.notes[i].num / (float)_inputJson.notes[i].LPB) + _inputJson.offset + 0.01f; //�m�[�c�̍~���Ă��鎞��

                NotesTime.Add(time);                    //NotesTime���X�g�ɒǉ�
                LaneNum.Add(_inputJson.notes[i].block);  //LaneNum���X�g�ɒǉ�
                NoteType.Add(_inputJson.notes[i].type);  // NoteType���X�g�ɒǉ�

                float z = NotesTime[i] * _notesSpeed;     //�m�[�c�̐��������ʒu

                NotesObject.Add(Instantiate(_noteObject, new Vector3(_inputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));//�m�[�c�����E�C���X�^���X��
            }
        }

    }
}