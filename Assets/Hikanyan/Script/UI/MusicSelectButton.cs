using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hikanyan.Core;
using UnityEngine.UI;
using Hikanyan.Runner;

public class MusicSelectButton : MonoBehaviour
{
    MusicData _musicData;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GameOpen);
        _musicData = GetComponent<MusicData>();
    }
    void GameOpen()
    {
        GameManager.Instance.MusicData(_musicData);
    }
}
