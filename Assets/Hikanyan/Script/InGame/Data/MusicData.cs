using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Hikanyan.Core {
    public class MusicData : MonoBehaviour
    {
        public int MusicNumber;
        public AssetReferenceT<TextAsset> MusicJsonReference;
        public float DelayTime;
    }
}