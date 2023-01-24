using Hikanyan.Core;
using Hikanyan.JudgeData;
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
    /// 叩いたときのSEの設定
    /// パーティクル
    /// 叩いたときのUI
    /// スコア加算
    /// 叩いたときの処理
    /// ホールドは未実装
    /// </summary>
    public class NotesManager : SingletonBehaviour<NotesManager>
    {
        [SerializeField, Tooltip("パーフェクトのときの効果音(CueSheetNumber)")]
        public int _perfectSoundNumber;
        [SerializeField, Tooltip("グレートのときの効果音(CueSheetNumber)")]
        public int _greatSoundNumber;
        [SerializeField, Tooltip("グッドのときの効果音(CueSheetNumber)")]
        public int _goodSoundNumber;
        [SerializeField, Tooltip("ミスのときの効果音(CueSheetNumber)")]
        public int _missSoundNumber;
        [SerializeField, Tooltip("何もないときのときの効果音(CueSheetNumber)")]
        public int _noneTapSoundNumber;
        //[SerializeField, Tooltip("パーフェクトのときの効果音(CueSheetNumber)")]
        //public int _holdSoundNumber;

        [SerializeField]
        Text _judgeText;
        bool _autoMode;
        float _judgeOffset = 0.0f;

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
        /// <summary>
        /// ノーツの当たり判定を行う。
        /// プレイヤーから情報を受け取り、
        /// インターフェイスで実行する
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

            //+で早く叩いても反応, -で遅く叩いても反応
            judgetime += _judgeOffset;


            if (JudgeTime.JudgeNotes(judgetime) != Judges.None)
            {
                //ダメージノーツを押さなかったら
                if (notes.NotesType != NotesType.DamageNotes)
                {
                    ApplyJudge(JudgeTime.JudgeNotes(judgetime), notes.Block);
                }

                //シングルノーツを押したとき
                if ((notes.NotesType == NotesType.NormalNotes) && !release)
                {

                    notes.SetVisible(false);
                    NotesManager.Instance.BlockNotes[notes.Block].RemoveAt(0);
                }
                //ダメージノーツを押したとき
                if (notes.NotesType == NotesType.DamageNotes && !release)
                {
                    ApplyJudge(Judges.Miss, notes.Block);
                    NotesManager.Instance.BlockNotes[notes.Block].RemoveAt(0);
                    notes.SetVisible(false);
                }
                //ホールドの最初押したとき
                if (notes.NotesType == NotesType.HoldNotes && !release)
                {
                   
                }
            }
            else
            {
                //空タップ
                CRIAudioManager.Instance.CRIPlaySE(_noneTapSoundNumber,false);
            }
        }

        public void BlockPress(int block)
        {
            if (BlockNotes[block].Count < 1) return;
            if (BlockNotes[block][0].NotesType == NotesType.NormalNotes) return;
            NotesJudge(BlockNotes[block][0], false);

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

                AudioClip selectSound = null;
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
                        selectSoundNumber = _goodSoundNumber;
                        break;
                    case Judges.Miss:
                        selectSoundNumber = _missSoundNumber;
                        break;
                    case Judges.None:
                        break;

                }


                CRIAudioManager.Instance.CRIPlaySE(selectSoundNumber, false);
            }
        }
    }
}