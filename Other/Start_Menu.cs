using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Start_Menu : MonoBehaviour {
    public string GotoScene;
    public bool hide_con;  //สั่งเมนูเล่นต่อ ไม่มีเซพ เป็น false
    public GameObject hideBT,hideText;
	// Use this for initialization
	void Start () {
        hide_con = false;
        loadsave();

    }
	
	// Update is called once per frame
	void Update () {
        if (hide_con == true)
        {
            hideBT.gameObject.SetActive(true);
            hideText.gameObject.SetActive(false);
        }
        else
        {
            hideBT.gameObject.SetActive(false);
            hideText.gameObject.SetActive(true);
        }
	}

    public void InputButton(string BT_Name)
    {
        if (BT_Name == "Start Game")
        {
            PlayerPrefs.SetString("Secenenexts", "Scene Intro");
            Application.LoadLevel("" + GotoScene);
            PlayerPrefs.DeleteAll();
        }
        else if (BT_Name == "Exit Game")
            Application.Quit();
        else if (BT_Name == "Load Game")
            Application.LoadLevel("Scene SpaceCraft");
        else if (BT_Name == "Delete Save")
            PlayerPrefs.DeleteAll();
        else if (BT_Name == "Back")
            Application.LoadLevel("Scene StartMenu");
        else if (BT_Name == "Tutorial")
            Application.LoadLevel("Scene Tutorial");
    }

    public void loadsave()
    {
        print("load Game");
        if (PlayerPrefs.GetInt("Mercury_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Venus_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Earth_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Mars_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Jupiter_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Saturn_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Uranus_Score") > 2)
            hide_con = true;
        if (PlayerPrefs.GetInt("Neptune_Score") > 2)
            hide_con = true;
    }
}
