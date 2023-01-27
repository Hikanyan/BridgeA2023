using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void InGameOnClickStartButton()
    {
        SceneManager.LoadScene("InGame");
    }
    public void TextOnClickStartButton01()
    {
        SceneManager.LoadScene("Setumei");
    }
    public void RetunTitleButton()
    {
        SceneManager.LoadScene("TitleUi");
    }
}
