using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public string Secenenexts;
    GotoScene SceneName;
    // Use this for initialization
    void Start()
    {
        Secenenexts = PlayerPrefs.GetString("Secenenext");
        print(PlayerPrefs.GetString("Secenenext"));
        Application.LoadLevel("Scene Intro");
    }
}

