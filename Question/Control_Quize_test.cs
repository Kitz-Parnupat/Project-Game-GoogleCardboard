using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Control_Quize_test : MonoBehaviour
{
    public Text Text_Btn1, Text_Btn2, Text_Btn3, Text_Btn4, Text_Btn5, Text_Btn6, Text_Btn7, Text_Btn8, Text_Btn9;
    public string Btn1, Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9;
    public int planet;

    // Use this for initialization
    void Start()
    {

        Text_Btn1.text = Btn1;
        Text_Btn2.text = Btn2;
        Text_Btn3.text = Btn3;
        Text_Btn4.text = Btn4;
        Text_Btn5.text = Btn5;
        Text_Btn6.text = Btn6;
        Text_Btn7.text = Btn7;
        Text_Btn8.text = Btn8;
        Text_Btn9.text = Btn9;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Btn_planet()
    {
        // Btsunn_sun();
    }
    public void Btn_sun()
    {
        PlayerPrefs.SetString("Name_planet_q", "Sun");
        Application.LoadLevel("Quection");
    }
    public void Btn_Mercury()
    {
        PlayerPrefs.SetString("Name_planet_q", "Mercury");
        Application.LoadLevel("Quection");
    }
    public void Btn_Venus()
    {
        PlayerPrefs.SetString("Name_planet_q", "Venus");
        Application.LoadLevel("Quection");
    }
    public void Btn_Word()
    {
        PlayerPrefs.SetString("Name_planet_q", "Word");
        Application.LoadLevel("Quection");
    }
    public void Btn_Mars()
    {
        PlayerPrefs.SetString("Name_planet_q", "Mars");
        Application.LoadLevel("Quection");
    }
    public void Btn_Jupiter()
    {
        PlayerPrefs.SetString("Name_planet_q", "Jupiter");
        Application.LoadLevel("Quection");
    }
    public void Btn_Saturn()
    {
        PlayerPrefs.SetString("Name_planet_q", "Saturn");
        Application.LoadLevel("Quection");
    }
    public void Btn_Uranus()
    {
        PlayerPrefs.SetString("Name_planet_q", "Uranus");
        Application.LoadLevel("Quection");
    }
    public void Btn_Neptune()
    {
        PlayerPrefs.SetString("Name_planet_q", "Neptune");
        Application.LoadLevel("Quection");
    }
}
