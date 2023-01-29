using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hikanyan.Core;
using UnityEngine.UI;
using Hikanyan.Runner;


public class MusicSelectButton : MonoBehaviour
{
    MusicData _musicData;
    OpenMusic _openMusic;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GameOpen);
        _musicData = GetComponent<MusicData>();
        _openMusic = GameObject.FindObjectOfType<OpenMusic>();
    }
    void GameOpen()
    {
        _openMusic.SelectMusic(_musicData);
    }
}
