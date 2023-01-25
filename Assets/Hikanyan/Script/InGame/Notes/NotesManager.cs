using Hikanyan.Core;
using Hikanyan.Gameplay;
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

        [SerializeField]
        TextMeshProUGUI _judgeText;
        bool _autoMode;
        float _judgeOffset = 0.0f;

        public List<Notes>[] BlockNotes = new List<Notes>[3];

        public void SetBlockNotes(List<Notes>[] blockNoteslist)
        {
            BlockNotes = blockNoteslist;
            int notesNum = 0;
            foreach (var blockNoteCount in BlockNotes)
            {
                foreach (var notesCount in blockNoteCount)
                {
                    notesNum++;
                }
            }
            ScoreManager.Instance.NotesNum = notesNum;
        }
        /// <summary>
        /// �m�[�c�̓����蔻����s���B
        /// �v���C���[��������󂯎��A
        /// �C���^�[�t�F�C�X�Ŏ��s����
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="release"></param>
        public void NotesJudge(Notes notes, bool release)
        {
            float judgetime = GameTimer.Instance.RealTime - notes.Time;

            if (release && notes.NotesType == NotesType.NormalNotes)
            {
                judgetime = GameTimer.Instance.RealTime - notes.EndTime;
            }

            //+�ő����@���Ă�����, -�Œx���@���Ă�����
            judgetime += _judgeOffset;


            if (JudgeTime.JudgeNotes(judgetime) != Judges.None)
            {
                //�_���[�W�m�[�c�������Ȃ�������
                if (notes.NotesType != NotesType.DamageNotes)
                {
                    ApplyJudge(JudgeTime.JudgeNotes(judgetime), notes.Block);
                }

                //�V���O���m�[�c���������Ƃ�
                if ((notes.NotesType == NotesType.NormalNotes) && !release)
                {

                    notes.SetVisible(false);
                    NotesManager.Instance.BlockNotes[notes.Block].RemoveAt(0);
                }
                //�_���[�W�m�[�c���������Ƃ�
                if (notes.NotesType == NotesType.DamageNotes && !release)
                {
                    ApplyJudge(Judges.Miss, notes.Block);
                    NotesManager.Instance.BlockNotes[notes.Block].RemoveAt(0);
                    notes.SetVisible(false);
                }
                //�z�[���h�̍ŏ��������Ƃ�
                if (notes.NotesType == NotesType.HoldNotes && !release)
                {

                }
            }
            else
            {
                //��^�b�v
                CRIAudioManager.Instance.CRIPlaySE(_noneTapSoundNumber, false);
            }
        }

        public void BlockPress(int block)
        {
            if (BlockNotes[block].Count < 1) return;
            if (BlockNotes[block][0].NotesType == NotesType.NormalNotes) return;
            NotesJudge(BlockNotes[block][0], false);
        }
        public void BlockRelease(int block)
        {
            if (BlockNotes[block].Count <= 0) return;
            if (BlockNotes[block][0].NotesType != NotesType.HeelNotes) return;
            NotesJudge(BlockNotes[block][0], true);
        }

        public void BlockALLPress()
        {
            float fastTime = 1000.0f;
            List<int> fastBlocks =new();
            for(int i=0; i<4; i++)
            {
                float curTime = 1000;
                
                if (BlockNotes[i].Count < 1) continue;

                if (fastTime == curTime)
                {
                    fastBlocks.Add(i);
                }
                else if (fastTime > curTime)
                {
                    fastTime = curTime;
                    fastBlocks.Clear();
                    fastBlocks.Add(i);
                }
            }
            if (fastBlocks.Count < 1) return;
            foreach (int i in fastBlocks)
            {
                NotesJudge(BlockNotes[i][0], false);
            }
        }
        public void ApplyJudge(Judges judge, int block, bool showParticle = true)
        {
            ScoreManager.Instance.AddScore(judge);

            if (Judges.PurePerfect == judge)
            {
                ScoreManager.Instance.Combo(true);
                ScoreManager.Instance.JudgeScores.PurePerfect++;
            }
            else if (Judges.Perfect == judge)
            {
                ScoreManager.Instance.Combo(true);
                ScoreManager.Instance.JudgeScores.Perfect++;
            }
            else if (Judges.Great == judge)
            {
                ScoreManager.Instance.Combo(true);
                ScoreManager.Instance.JudgeScores.Great++;
            }
            else if (Judges.Good == judge)
            {
                ScoreManager.Instance.Combo(false);
                ScoreManager.Instance.JudgeScores.Good++;

            }
            else if (Judges.Bad == judge)
            {
                ScoreManager.Instance.Combo(false);
                ScoreManager.Instance.JudgeScores.Bad++;
            }
            else if (Judges.Miss == judge)
            {
                ScoreManager.Instance.Combo(false);
                ScoreManager.Instance.JudgeScores.Miss++;
            }

            if (showParticle)
            {
                //ParticleManager.Instance.JudgeEffect(judge, block);

                int selectSoundNumber = default;
                switch (judge)
                {
                    case Judges.PurePerfect:
                    case Judges.Perfect:
                        selectSoundNumber = _perfectSoundNumber;
                        break;
                    case Judges.Great:
                        selectSoundNumber = _greatSoundNumber;
                        break;
                    case Judges.Good:
                        selectSoundNumber = _goodSoundNumber;
                        break;
                    case Judges.Bad:
                    case Judges.Miss:
                        selectSoundNumber = _missSoundNumber;
                        break;
                    case Judges.None:
                        break;

                }


                CRIAudioManager.Instance.CRIPlaySE(selectSoundNumber, false);
            }
        }

        void AutoMode()
        {
            if (!_autoMode) return;
            for (int i = 0; i < 4; i++)
            {
                if (BlockNotes[i].Count <1)return;
                if (BlockNotes[i][0].NotesType != NotesType.DamageNotes)
                {
                    BlockPress(i);
                }

            }
        }
    }
}