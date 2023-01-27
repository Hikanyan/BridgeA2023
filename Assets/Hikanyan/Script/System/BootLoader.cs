using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hikanyan.Runner
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField, Tooltip("SequenceManagerPrefab������")]
        SequenceManager _sequenceManagerPrefab;
        void Awake()
        {
            Instantiate(_sequenceManagerPrefab);
            SequenceManager.Instance.Initialize();
        }
    }
}

