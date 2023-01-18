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