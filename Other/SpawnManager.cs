using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {
    public GameObject SpawnAsteroid, SpawnCrystals,GameClear,MissionGameClear;
    SpaceCraftController Space;
    public bool CheckClear;
    public Text head, detail,text;
    public Image filled;
    private float cooldown = 0, maxCooldown = 100;
	// Use this for initialization
	void Start () {
        GameObject connect = GameObject.FindGameObjectWithTag("Player");
        if (connect != null)
            Space = connect.GetComponent<SpaceCraftController>();
        else if (connect == null)
            print("Canot fine SpaceCraftController");
	}
	
	// Update is called once per frame
	void Update () {
        if (Space.GetCryStal == 4)
        {
           // print("Game Clear");
            SpawnAsteroid.gameObject.SetActive(false);
            SpawnCrystals.gameObject.SetActive(false);
            MissionGameClear.gameObject.SetActive(false);
            SetText();
        }
        if (CheckClear == true)
        {
            Cool_Down();
        }
    }
    void SetText()
    {
        StartCoroutine(DelayTime());
        if (CheckClear == true)
        {
            head.text = "   Game Clear";
            detail.text = "กำลังกลับยาน...";
            //GameClear.gameObject.SetActive(true);
            StartCoroutine(DelayTime());
        }
    }
  void Cool_Down()
    {
        cooldown += Time.deltaTime * 10;
        cooldown = Mathf.Clamp(cooldown, 0, maxCooldown);
        float amount = cooldown / maxCooldown;
        filled.fillAmount = amount;
        text.text = Mathf.RoundToInt(cooldown).ToString() + "%";
        if (cooldown == maxCooldown)
            Application.LoadLevel("Scene Question");
    }
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(5);
        CheckClear = true;
        yield break;
    }

    
}
