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
    /// </summary>
    public class NotesManager : SingletonBehaviour<NotesManager>
    {
        [SerializeField, Tooltip("パーフェクトのときの効果音(CueSheetNumber)")]
        int _perfectSoundNumber;
        [SerializeField, Tooltip("グッドのときの効果音(CueSheetNumber)")]
        int _goodSoundNumber;
        [SerializeField, Tooltip("ミスのときの効果音(CueSheetNumber)")]
        int _missSoundNumber;

        [SerializeField, Tooltip("パーフェクトのときのパーティクル")]
        int _perfectParticle;
        [SerializeField, Tooltip("グッドのときのパーティクル")]
        int _goodParticle;
        [SerializeField, Tooltip("ミスのときのパーティクル")]
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