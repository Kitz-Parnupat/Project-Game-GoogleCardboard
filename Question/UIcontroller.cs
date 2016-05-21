using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIcontroller : MonoBehaviour {
    public int Score_1;
    public Text score_text_1, score_text_2, score_text_3, score_text_4, score_text_5, score_text_6, score_text_7, score_text_8,
                Status_1, Status_2, Status_3, Status_4, Status_5, Status_6, Status_7, Status_8;
    //สี ตัวอักษร
    public Color32 clear= new Color32(19, 152, 25, 255);
    //คำ ว่า clear
    public string clear_a = "clear";
    //public string Status_m;
    //Use this for initialization
    void Start () {
        /*Score = 3;
        PlayerPrefs.SetInt("Mercury_Score", Score);
        PlayerPrefs.SetInt("Venus_Score", Score);
        PlayerPrefs.SetInt("Word_Score", Score);
        PlayerPrefs.SetInt("Mars_Score", Score);
        PlayerPrefs.SetInt("Jupiter_Score", Score);
        PlayerPrefs.SetInt("Saturn_Score", Score);
        PlayerPrefs.SetInt("Uranus_Score", Score);
        PlayerPrefs.SetInt("Neptune_Score", Score);
        Score = PlayerPrefs.GetInt("Mercury_Score");
         */
        //PlayerPrefs.DeleteAll();
        score_text_1.text = PlayerPrefs.GetInt("Mercury_Score").ToString();
        score_text_2.text = PlayerPrefs.GetInt("Venus_Score").ToString();
        score_text_3.text = PlayerPrefs.GetInt("Earth_Score").ToString();
        score_text_4.text = PlayerPrefs.GetInt("Mars_Score").ToString();
        score_text_5.text = PlayerPrefs.GetInt("Jupiter_Score").ToString();
        score_text_6.text = PlayerPrefs.GetInt("Saturn_Score").ToString();
        score_text_7.text = PlayerPrefs.GetInt("Uranus_Score").ToString();
        score_text_8.text = PlayerPrefs.GetInt("Neptune_Score").ToString();
        color_text();
    }
	
	// Update is called once per frame
	public void color_text () {

        if (PlayerPrefs.GetInt("Mercury_Score") > 0)
        {
            Status_1.text = clear_a;
            Status_1.color = clear;
        }
        if (PlayerPrefs.GetInt("Venus_Score") > 0)
        {
            Status_2.text = clear_a;
            Status_2.color = clear;
        }
        if (PlayerPrefs.GetInt("Earth_Score") > 0)
        {
            Status_3.text = clear_a;
            Status_3.color = clear;
        }
        if (PlayerPrefs.GetInt("Mars_Score") > 0)
        {
            Status_4.text = clear_a;
            Status_4.color = clear;
        }
        if (PlayerPrefs.GetInt("Jupiter_Score") > 0)
        {
            Status_5.text = clear_a;
            Status_5.color = clear;
        }
        if (PlayerPrefs.GetInt("Saturn_Score") > 0)
        {
            Status_6.text = clear_a;
            Status_6.color = clear;
        }
        if (PlayerPrefs.GetInt("Uranus_Score") > 0)
        {
            Status_7.text = clear_a;
            Status_7.color = clear;
        }
        if (PlayerPrefs.GetInt("Neptune_Score") > 0)
        {
            Status_8.text = clear_a;
            Status_8.color = clear;
        }
    }
}
