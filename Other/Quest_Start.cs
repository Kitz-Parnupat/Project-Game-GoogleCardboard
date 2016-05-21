using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Quest_Start : MonoBehaviour
{
    public Text Text_Plannet_name;
    // Use this for initialization
    public GameObject Btnstart;
    public string Plannet_name;
    void Start()
    {

        Plannet_name = PlayerPrefs.GetString("Name_planet_q");
        Text_Plannet_name.text = Plannet_name;

    }
    public void Btn_Start(bool check)
    {
        if (check == true)
        {
            Application.LoadLevel("Scene Question_Start");
        }
    }
}
