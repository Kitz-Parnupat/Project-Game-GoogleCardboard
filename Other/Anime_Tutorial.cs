using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Anime_Tutorial : MonoBehaviour {
    public Text AnimeText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void SetText(string TextInput)
    {
        AnimeText.text = "" + TextInput;
    }
}
