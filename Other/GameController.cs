using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    PlayerController player;
    public GameObject WarpEnd;
    // Set Text UI 
    public string Data1, Data2, Data3, Data4,planetName;
    public Text T_Data1, T_Data2, T_Data3, T_Data4,T_DataPlay,T_DataHead, T_DataHead2;
    public GameObject UI_Animation, UI_AnimationPlay, UI_Crystal,UI_MissionCom;
    // Use this for initialization
    void Start () {
        GameObject connect = GameObject.FindGameObjectWithTag("Player");
        UI_Animation.gameObject.SetActive(false);
        UI_AnimationPlay.gameObject.SetActive(false);
        WarpEnd.gameObject.SetActive(false);
        UI_MissionCom.gameObject.SetActive(false);
       
        if (connect != null)
            player = connect.GetComponent<PlayerController>();
        
        else if (connect == null)
            print("Canot find PlayerController");

        WarpEnd.gameObject.SetActive(false);

        UI_Crystal.gameObject.SetActive(true);
        StartCoroutine(Wait_Time());
    }
    void FixedUpdate()
    {
        if (player.GetTrigger == true)
        {
            print("Show Trigger");
            ShowUI();
        }
        SetTextUI();
    }

    public void SetTextUI()
    {
        T_Data1.text = "" + Data1;
        T_Data2.text = "" + Data2;
        T_Data3.text = "" + Data3;
        T_Data4.text = "" + Data4;
    }

    public void ShowUI()
    {
        if(player.GetCryStal == 1)
        {
            T_DataPlay.text = "" + Data1;
            UI_AnimationPlay.gameObject.SetActive(true);
            StartCoroutine(Wait_Time());
        }
        else if (player.GetCryStal == 2)
        {
            T_DataPlay.text = "" + Data2;
            UI_AnimationPlay.gameObject.SetActive(true);
            StartCoroutine(Wait_Time());
        }
        else if (player.GetCryStal == 3)
        {
            T_DataPlay.text = "" + Data3;
            UI_AnimationPlay.gameObject.SetActive(true);
            StartCoroutine(Wait_Time());
        }
        else if (player.GetCryStal == 4)
        {
            T_DataPlay.text = "" + Data4;
            StartCoroutine(Wait_Time());
            UI_Animation.gameObject.SetActive(true);
            WarpEnd.gameObject.SetActive(true);
            UI_MissionCom.gameObject.SetActive(true);
        }
        T_DataHead.text = "ข้อมูล : " + planetName;
        T_DataHead2.text = "ข้อมูล : " + planetName;

    }

    IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(5);
        print("Break");
        UI_AnimationPlay.gameObject.SetActive(false);
        if (player.GetCryStal == 4)
        {
            UI_Animation.gameObject.SetActive(false);
            
        }
        UI_Crystal.gameObject.SetActive(false);
        yield break;
    }
}
