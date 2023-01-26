using Hikanyan.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

namespace Hikanyan.Runner
{
    public class CRIAudioManager : SingletonBehaviour<CRIAudioManager>
    {
        [SerializeField, Tooltip("ACFの名前を入力")]
        string _streamingAssetsPathACF;
        [SerializeField, Tooltip("CueSheetのBGMの名前を入力")]
        string _cueSheetBGM;
        [SerializeField, Tooltip("CueSheetのSEの名前を入力")]
        string _cueSheetSE;

        [SerializeField, Range(0f, 1f), Tooltip("BGMのボリューム")]
        float _playVolumeBGM = default;
        [SerializeField, Range(0f, 1f), Tooltip("SEのボリューム")]
        float _playVolumeSE = default;

        CriAtomExPlayback _criAtomExPlayback;
        CriAtomEx.CueInfo _cueInfo;

        CriAtomSource _criAtomSourceBGM;
        CriAtomSource _criAtomSourceSE;

        int _cueIndexID;

        protected override void OnAwake()
        {
            //acf
            string path = Common.streamingAssetsPath + $"/{_streamingAssetsPathACF}.acf";
            CriAtomEx.RegisterAcf(null, path);

            //CriAtom
            new GameObject().AddComponent<CriAtom>();

            //BGM.acb
            CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
            //SE.acb
            CriAtom.AddCueSheet(_cueSheetSE, $"{_cueSheetSE}.acb", null, null);

            //CriAtomSourceBGM
            _criAtomSourceBGM = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceBGM.cueSheet = _cueSheetBGM;
            //CriAtomSourceSE
            _criAtomSourceSE = gameObject.AddComponent<CriAtomSource>();
            _criAtomSourceSE.cueSheet = _cueSheetSE;
        }

        private void Start()
        {
            //ゲーム内プレビュー用のレベルモニター機能を追加
            CriAtom.SetBusAnalyzer(true);
        }
        public void CRIPlayBGM(int index)
        {
            bool startFlag = false;
            CriAtomSource.Status status = _criAtomSourceBGM.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
            {
                this._criAtomExPlayback = _criAtomSourceBGM.Play(index);
                startFlag = true;
            }
            if (startFlag == false)
            {
                int cur = this._criAtomExPlayback.GetCurrentBlockIndex();
                CriAtomExAcb acb = CriAtom.GetAcb(_cueSheetBGM);
                if (acb != null)
                {
                    acb.GetCueInfo(index, out _cueInfo);

                    cur++;
                    if (_cueInfo.numBlocks > 0)
                    {
                        _criAtomExPlayback.SetNextBlockIndex(cur % _cueInfo.numBlocks);
                    }
                }
            }
        }
        public void CRIPlayBGM(int index, float delayTime)
        {
            StartCoroutine(CRIDelayPlaySound(index, delayTime));
        }
        private IEnumerator CRIDelayPlaySound(int index, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            CRIPlayBGM(index);
        }

        public void CRILoopBGM(bool isTrue) => _criAtomSourceBGM.loop = isTrue;
        public void CRIPauseAudio() => _criAtomSourceBGM.Pause(true);
        public void CRIResume() => _criAtomSourceBGM.Pause(false);
        public void CRIPlaySE(int index, bool isLoop)
        {
            _criAtomSourceSE.loop = isLoop;
            this._criAtomExPlayback = _criAtomSourceSE.Play(index);
        }
        public void CRILoopSE(int index) => CRIPlaySE(index, true);
        public void CRIStopSE(int index) => _criAtomSourceSE.Stop();
    }
}
