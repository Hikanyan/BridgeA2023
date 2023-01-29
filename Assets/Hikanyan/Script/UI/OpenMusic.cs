using Hikanyan.Core;
using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMusic : MonoBehaviour
{
    public MusicData _musicData;
    [SerializeField]
    private string _sceneName = "Test1";
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SelectMusic(MusicData musicdata)
    {
        _musicData = musicdata;
    }
}
