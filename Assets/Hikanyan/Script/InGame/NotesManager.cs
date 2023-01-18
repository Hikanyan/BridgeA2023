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
    /// </summary>
    public class NotesManager : SingletonBehaviour<NotesManager>
    {
        [SerializeField, Tooltip("�p�[�t�F�N�g�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        int _perfectSoundNumber;
        [SerializeField, Tooltip("�O�b�h�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        int _goodSoundNumber;
        [SerializeField, Tooltip("�~�X�̂Ƃ��̌��ʉ�(CueSheetNumber)")]
        int _missSoundNumber;

        [SerializeField, Tooltip("�p�[�t�F�N�g�̂Ƃ��̃p�[�e�B�N��")]
        int _perfectParticle;
        [SerializeField, Tooltip("�O�b�h�̂Ƃ��̃p�[�e�B�N��")]
        int _goodParticle;
        [SerializeField, Tooltip("�~�X�̂Ƃ��̃p�[�e�B�N��")]
        int _missParticle;

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
            ScoreManager.Instance
        }
    }
}