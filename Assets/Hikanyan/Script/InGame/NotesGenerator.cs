using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Gameplay
{
    /// <summary>
    /// 全体のデータ
    /// </summary>
    [Serializable]
    public class NotesData
    {
        public TapNotesInput[] tapNotes;
        public HoldNotesInput[] holdNotes;
    }
    /// <summary>
    /// タップノーツのデータ
    /// </summary>
    [Serializable]
    public class TapNotesInput
    {
        public int type;
        public float time;
        public int block;
    }
    /// <summary>
    /// ホールドノーツのデータ
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
        /// どのレーンにノーツが落ちてくるか
        /// </summary>
        public List<int> LaneNum = new();
        /// <summary>
        /// Notesの種類
        /// </summary>
        public List<int> HoldType = new();
        /// <summary>
        /// ノーツが判定線に重なる時間
        /// </summary>
        public List<int> NotesTime = new();
        /// <summary>
        /// ノーツのオブジェクト
        /// </summary>
        public List<GameObject> NotesObject = new();
        /// <summary>
        /// タップノーツのプレハブを入れる
        /// </summary>
        [SerializeField]GameObject _tapNotesObject;
        /// <summary>
        /// ノーツのスピード
        /// </summary>
        [SerializeField]float _notesSpeed;
        /// <summary>
        /// ノーツの表示される奥行き(両サイド)
        /// </summary>
        [SerializeField] float _blockHeight;

        private void Start()
        {
            //プレイヤー設定をロード
            //
        }
       　void StartLoad()
        {

        }

    }
}