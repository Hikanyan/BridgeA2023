using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Hikanyan.Runner
{
    /// <summary>
    /// [TODO]
    /// �@�����Ƃ���SE�̐ݒ�
    /// �p�[�e�B�N��
    /// �@�����Ƃ���UI
    /// �X�R�A���Z
    /// �@�����Ƃ��̏���
    /// �z�[���h�͖�����
    /// </summary>
    public class NotesManager : SingletonBehaviour<NotesManager>
    {
        [SerializeField, Tooltip("�p�[�t�F�N�g�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        public int _perfectSoundNumber;
        [SerializeField, Tooltip("�O���[�g�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        public int _greatSoundNumber;
        [SerializeField, Tooltip("�O�b�h�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        public int _goodSoundNumber;
        [SerializeField, Tooltip("�~�X�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        public int _missSoundNumber;
        [SerializeField, Tooltip("�����Ȃ��Ƃ��̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        public int _noneTapSoundNumber;
        //[SerializeField, Tooltip("�p�[�t�F�N�g�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        //public int _holdSoundNumber;

        [SerializeField]
        Text _judgeText;

        public List<Notes>[] BlockNotes = new List<Notes>[3];

        public void SetBlockNotes(List<Notes>[] blockNoteslist)
        {
            BlockNotes = blockNoteslist;
            int notesNum = 0;
            foreach(var blockNoteCount in BlockNotes)
            {
                foreach(var notesCount in blockNoteCount)
                {
                    notesNum++;
                }
            }
            ScoreManager.Instance.NotesNum = notesNum;
        }
    }
}