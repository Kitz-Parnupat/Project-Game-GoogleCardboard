using UnityEngine;
using System.Collections;

public class GotoScene : MonoBehaviour {
    public string SceneName;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void LoadScene()
    {
        Application.LoadLevel("loading");
    }
}
