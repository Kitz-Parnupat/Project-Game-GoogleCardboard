using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_PlanetMenu : MonoBehaviour {
    public string PlanetName;
    public GameObject Exittarget, WarpPlanet, Missiontarget;
    public GameObject player;
    public GameObject UI,terain,gas,other;
   // public GameObject Button;
	void Start () {
        /* GameObject myEventSystem = GameObject.Find("EventSystem");
         myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(Button);*/
        ClearMenu();
    }
	void Update () {
        //if (player.gameObject.transform.position == Missiontarget.transform.position) ;
	}
 
    public void InputButton(string Input_BT)
    {
        if (Input_BT == "Back")
        {
            ClearMenu();
            player.gameObject.transform.position = Exittarget.transform.position;
            player.gameObject.transform.rotation = Exittarget.transform.rotation;
        }
        else if (Input_BT == "Sun") Application.LoadLevel("Scene AnimSun");
        else if (Input_BT == "Asteroid") Application.LoadLevel("Scene AnimAsteroid");

        else {
            PlanetName = "" + Input_BT;
            PlayerPrefs.SetString("Name_planet_q", Input_BT);
            print("" + Input_BT);
            player.gameObject.transform.position = WarpPlanet.transform.position;
            player.gameObject.transform.rotation = WarpPlanet.transform.rotation;
        }
    }
    public void InputMenu(string Input_BT)
    {
        if (Input_BT == "Terain")
        {
            ClearMenu();
            terain.gameObject.SetActive(true);
        }
        else if (Input_BT == "Gas")
        {
            ClearMenu();
            gas.gameObject.SetActive(true);
        }
        else if (Input_BT == "other")
        {
            ClearMenu();
            other.gameObject.SetActive(true);
        }

    }
    void ClearMenu()
    {
        terain.gameObject.SetActive(false);
        gas.gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }

 
}


/*GameObject myEventSystem = GameObject.Find("EventSystem");
myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(FirstSelect);*/

// Connect To Player 
/*   void OnTrriggerEnter(GameObject other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
           print("Player Inside Warp !!");
           Application.LoadLevel(PlanetName);
       }
   }*/
