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
    /// 全体のデータ
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
    /// タップノーツのデータ
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
        /// <summary>ノーツの総数 </summary>
        public int NoteNum;
        /// <summary>何番目のレーンにノーツが落ちてくるか </summary>
        public List<int> LaneNum = new();
        /// <summary>Notesの種類 </summary>
        public List<int> NoteType = new();
        /// <summary>ノーツが判定線と重なる時間 </summary>
        public List<float> NotesTime = new();
        /// <summary>ノーツのオブジェクト</summary>
        public List<GameObject> NotesObject = new();


        /// <summary>曲名</summary>
        public AssetReferenceT<TextAsset> _jsonMusic;//曲名を入れる関数を作成する。保存したJsonの名前を入れる
        /// <summary>シングルノーツのオブジェクト</summary>
        [SerializeField] private GameObject _noteObject;//ノーツのプレハブを入れる
        /// <summary>ロングノーツのオブジェクト</summary>
        [SerializeField] private GameObject _noteLongObject;//ロングノーツのプレハブを入れる
        /// <summary>ノーツのスピード</summary>
        [HideInInspector] public static float _notesSpeed = 5.0f;//ノーツのスピード
        /// <summary>ノーツが流れてくる猶予 </summary>
        public float _notesOffset;//ノーツが流れてくる遅延時間(未実装)


        private NotesData _inputJson;
        //コレクションのインスタンス化と同時に要素を追加
        private List<List<Notes>> _instanceNotesList = new List<List<Notes>>() { new(), new(), new(), new() };

        private void Start()
        {
            //有効にされたらJsonファイルを読み込み、座標を計算して配置する
            //プレイヤー設定をロード
        }
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(_notesOffset);
            StartLoad(_jsonMusic);
        }
        public async Task StartLoad(AssetReferenceT<TextAsset> jsonReference)
        {
            string inputString = "";
            //同期ロード
            //JsonのリファレンスをTestAssetに変換
            TextAsset data = await Addressables.LoadAssetAsync<TextAsset>(jsonReference).Task;
            inputString = data.text;

            _inputJson = JsonUtility.FromJson<NotesData>(inputString);

            Generat();
            GameManager.Instance.GameStart();
        }

        void Generat()
        {
            for (int i = 0; i < _inputJson.notes.Length; i++)//ノーツの位置を一個ずつ配置していく
            {
                float syousetu = 60 / (_inputJson.BPM * (float)_inputJson.notes[i].LPB);                                      //一小節の長さ
                float beatSec = syousetu * (float)_inputJson.notes[i].LPB;                                                   //ノーツの長さ
                float time = (beatSec * _inputJson.notes[i].num / (float)_inputJson.notes[i].LPB) + _inputJson.offset + 0.01f; //ノーツの降ってくる時間

                NotesTime.Add(time);                    //NotesTimeリストに追加
                LaneNum.Add(_inputJson.notes[i].block);  //LaneNumリストに追加
                NoteType.Add(_inputJson.notes[i].type);  // NoteTypeリストに追加

                float z = NotesTime[i] * _notesSpeed;     //ノーツの生成される位置

                NotesObject.Add(Instantiate(_noteObject, new Vector3(_inputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));//ノーツ生成・インスタンス化
            }
        }

    }
}