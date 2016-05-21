using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Tutorial_Controller : MonoBehaviour {
    public GameObject Data1, Data2,BT_Data1,BT_Data2,CloseUI;
    public float Second;
    public bool Data1_Status = false, Data2_Status = false, Data_Status = false;
    PlayerController player;
	// Use this for initialization
	void Start () {
        Data1.gameObject.SetActive(true);
        Data2.gameObject.SetActive(false);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(BT_Data1);

        GameObject connect = GameObject.FindGameObjectWithTag("Player");
        if (connect != null)
            player = connect.GetComponent<PlayerController>();

        else if (connect == null)
            print("Canot find PlayerController");


        player.MoveControl = true;
    }
	
	// Update is called once per frame
	void Update () {
        UI_Controller();
        if (Data_Status == false)
            player.MoveControl = false;
    }

    public void InputButton(string InputBT)
    {
       
        if (InputBT == "OK_Data1")
        {
            Data1.gameObject.SetActive(false);
            Data1_Status = true;
        }
        else if (InputBT == "OK_Data2")
        {
            Data2.gameObject.SetActive(false);
            CloseUI.gameObject.SetActive(false);
            Data_Status = true;
            player.MoveControl = true;
        }

      
    }

    public void UI_Controller()
    {
        
        if (Data1_Status == true)
        {
            StartCoroutine(Waiting());
        }
        if(Data2_Status == true)
        {
           
        }
       // Data1_Status = false;
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Second);
        if (Data1_Status == true)
        {
            Data2.gameObject.SetActive(true);
            GameObject myEventSystem = GameObject.Find("EventSystem");
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(BT_Data2);
            Data1_Status = false;
            Data2_Status = true;
        }
    }
}
