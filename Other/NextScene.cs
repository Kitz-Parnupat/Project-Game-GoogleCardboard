using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {
    public string LoadScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void LoadSceneAnime()
    {
        Application.LoadLevel("Scene " + LoadScene);
    }

    public void InputBT(bool GetInput)
    {
        if (GetInput == true)
            LoadSceneAnime();
    }
}
