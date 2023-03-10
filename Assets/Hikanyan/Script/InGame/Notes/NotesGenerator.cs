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
        [SerializeField] GameObject _tapNotesObject;
        /// <summary>
        /// ノーツのスピード
        /// </summary>
        [SerializeField] float _notesSpeed;
        /// <summary>
        /// ノーツの表示される奥行き(両サイド)
        /// </summary>
        [SerializeField] float _blockHeight;


        private NotesData _inputJson;
        //コレクションのインスタンス化と同時に要素を追加
        private List<List<Notes>> _instanceNotesList = new List<List<Notes>>() { new(), new(), new(), new() };

        private void Start()
        {
            //有効にされたらJsonファイルを読み込み、座標を計算して配置する
            //プレイヤー設定をロード
        }
        public async Task StartLoad(AssetReferenceT<TextAsset> jsonReference)
        {
            string inputString = "";
            //同期ロード
            //JsonのリファレンスをTestAssetに変換
            TextAsset data = await Addressables.LoadAssetAsync<TextAsset>(jsonReference).Task;
            inputString = data.text;

            _inputJson = JsonUtility.FromJson<NotesData>(inputString);

            int TapNotes = _inputJson.tapNotes.Length;
            int HoldNotes = _inputJson.holdNotes.Length;

            //[TODO]
        }

        void Generat()
        {
            for (int i = 0; i < _inputJson.notes.Length; i++)//繝弱?ｼ繝?縺ｮ菴咲ｽｮ繧剃ｸ?蛟九★縺､驟咲ｽｮ縺励※縺?縺?
        {

        }

    }
}