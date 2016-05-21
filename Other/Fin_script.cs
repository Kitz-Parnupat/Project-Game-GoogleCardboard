using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fin_script : MonoBehaviour {
    public Text total_Text, total_Text2;
    public float score1, score2, score3, score4, score5, score6, score7, score8, total;
    //GameObject
   public GameObject planet_1, planet_2, planet_3, planet_4, planet_5, planet_6, planet_7, planet_8; //ภาพดาวที่ไม่เต็ม
    public GameObject Btn_return, Btn_game,Btn_left,Btn_right,canvas_left, canvas_right;

    // Use this for initialization
    void Start () {
        //ดึงค่าคะแนนมา
        PlayerPrefs.SetInt("Mercury_Score", 4);
        score1 = PlayerPrefs.GetInt("Mercury_Score");
        score2 = PlayerPrefs.GetInt("Venus_Score");
        score3 = PlayerPrefs.GetInt("Earth_Score");
        score4 = PlayerPrefs.GetInt("Mars_Score");
        score5 = PlayerPrefs.GetInt("Jupiter_Score");
        score6 = PlayerPrefs.GetInt("Saturn_Score");
        score7 = PlayerPrefs.GetInt("Uranus_Score");
        score8 = PlayerPrefs.GetInt("Neptune_Score");

        canvas_left.gameObject.SetActive(true);
        canvas_right.gameObject.SetActive(false);
        Btn_left.gameObject.SetActive(false);

      if (score1 > 3)
            planet_1.gameObject.SetActive(false);
        if (score2 > 3)
            planet_2.gameObject.SetActive(false);
        if (score3 > 3)
            planet_3.gameObject.SetActive(false);
        if (score4 > 3)
            planet_4.gameObject.SetActive(false);
        if (score5 > 3)
            planet_5.gameObject.SetActive(false);
        if (score6 > 3)
            planet_6.gameObject.SetActive(false);
        if (score7 > 3)
            planet_7.gameObject.SetActive(false);
        if (score8 > 3)
            planet_8.gameObject.SetActive(false);

        total = score1 + score2 + score3 + score4+ score5+ score6+ score7+ score8;
        total_Text.text = total.ToString()+ (" คะแนน จาก 32 คะแนน");
        total_Text2.text = total.ToString() + (" คะแนน จาก 32 คะแนน");
        
        //บวกคะแนน
        
        /*
        score1_Text.text = score1.ToString()+ (" คะแนน จาก 4 คะแนน");
        score2_Text.text = score2.ToString()+ (" คะแนน จาก 4 คะแนน");
        score3_Text.text = score3.ToString()+ (" คะแนน จาก 4 คะแนน");
        score4_Text.text = score4.ToString()+ (" คะแนน จาก 4 คะแนน");
        
        

        print(((score1+score2+score3+score4)/16)*100);
        */
    }
	
	public void Btn_check (int check) {
	 if(check == 1)
        {
            Application.LoadLevel("Scene SpaceCraft");
        }
        else
        {
            Application.LoadLevel("Scene StartMenu");
        }
	}
    public void Btn_right_ (int check_right)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        if (check_right == 1)
        {
            canvas_left.gameObject.SetActive(false);
            canvas_right.gameObject.SetActive(true);
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Btn_return);
            Btn_right.gameObject.SetActive(false);
            Btn_left.gameObject.SetActive(true);
        }
        else
        {
             canvas_left.gameObject.SetActive(true);
             canvas_right.gameObject.SetActive(false);
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Btn_return);
            Btn_right.gameObject.SetActive(true);
            Btn_left.gameObject.SetActive(false);
        }
    }
}
