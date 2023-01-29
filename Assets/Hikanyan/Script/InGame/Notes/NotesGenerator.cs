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
    /// ‘S‘Ì‚Ìƒf[ƒ^
    /// </summary>
    [Serializable]
    public class NotesData
    {
        public TapNotesInput[] tapNotes;
        public HoldNotesInput[] holdNotes;
    }
    /// <summary>
    /// ƒ^ƒbƒvƒm[ƒc‚Ìƒf[ƒ^
    /// </summary>
    [Serializable]
    public class TapNotesInput
    {
        public int type;
        public float time;
        public int block;
    }
    /// <summary>
    /// ƒz[ƒ‹ƒhƒm[ƒc‚Ìƒf[ƒ^
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
        /// ‚Ç‚ÌƒŒ[ƒ“‚Éƒm[ƒc‚ª—Ž‚¿‚Ä‚­‚é‚©
        /// </summary>
        public List<int> LaneNum = new();
        /// <summary>
        /// Notes‚ÌŽí—Þ
        /// </summary>
        public List<int> HoldType = new();
        /// <summary>
        /// ƒm[ƒc‚ª”»’èü‚Éd‚È‚éŽžŠÔ
        /// </summary>
        public List<int> NotesTime = new();
        /// <summary>
        /// ƒm[ƒc‚ÌƒIƒuƒWƒFƒNƒg
        /// </summary>
        public List<GameObject> NotesObject = new();
        /// <summary>
        /// ƒ^ƒbƒvƒm[ƒc‚ÌƒvƒŒƒnƒu‚ð“ü‚ê‚é
        /// </summary>
        [SerializeField] GameObject _tapNotesObject;
        /// <summary>
        /// ƒm[ƒc‚ÌƒXƒs[ƒh
        /// </summary>
        [SerializeField] float _notesSpeed;
        /// <summary>
        /// ƒm[ƒc‚Ì•\Ž¦‚³‚ê‚é‰œs‚«(—¼ƒTƒCƒh)
        /// </summary>
        [SerializeField] float _blockHeight;


        private NotesData _inputJson;
        //ƒRƒŒƒNƒVƒ‡ƒ“‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‰»‚Æ“¯Žž‚É—v‘f‚ð’Ç‰Á
        private List<List<Notes>> _instanceNotesList = new List<List<Notes>>() { new(), new(), new(), new() };

        private void Start()
        {
            //—LŒø‚É‚³‚ê‚½‚çJsonƒtƒ@ƒCƒ‹‚ð“Ç‚Ýž‚ÝAÀ•W‚ðŒvŽZ‚µ‚Ä”z’u‚·‚é
            //ƒvƒŒƒCƒ„[Ý’è‚ðƒ[ƒh
        }
        public async Task StartLoad(AssetReferenceT<TextAsset> jsonReference)
        {
            string inputString = "";
            //“¯Šúƒ[ƒh
            //Json‚ÌƒŠƒtƒ@ƒŒƒ“ƒX‚ðTestAsset‚É•ÏŠ·
            TextAsset data = await Addressables.LoadAssetAsync<TextAsset>(jsonReference).Task;
            inputString = data.text;

            _inputJson = JsonUtility.FromJson<NotesData>(inputString);

            int TapNotes = _inputJson.tapNotes.Length;
            int HoldNotes = _inputJson.holdNotes.Length;

            //[TODO]
        }

        void Generat()
        {
            for (int i = 0; i < _inputJson.notes.Length; i++)//ãƒŽãƒ¼ãƒ„ã®ä½ç½®ã‚’ä¸€å€‹ãšã¤é…ç½®ã—ã¦ã„ã
        {

        }

    }
}