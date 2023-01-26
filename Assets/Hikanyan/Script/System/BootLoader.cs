using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Gameplay
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField, Tooltip("SequenceManagerPrefab‚ð“ü‚ê‚é")]
        SequenceManager _sequenceManagerPrefab;
        void Start()
        {
            Instantiate(_sequenceManagerPrefab);
            SequenceManager.Instance.Initialize();
        }
    }
}

