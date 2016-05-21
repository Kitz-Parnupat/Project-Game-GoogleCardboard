using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceCraftController : MonoBehaviour {
    private Rigidbody rb;
    public float speed, PlayerHp, SetDamage, MaxHP, value, maxValue;
    public bool MoveControl, GetTrigger, EnterCollider;
    public int GetCryStal;
    public string PlanetName;

    CardboardHead head;
    Vector3 Direction;
    Quaternion Rotation;
    public GameObject Sh_GameOver, Sh_HealtBar, FPS, PauseUI,Area;
    public Image filled;
    public Text text, Sh_PlanetName, Sh_Crystal;
    private Animator myAnimator;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        head = Camera.main.GetComponent<StereoController>().Head;
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        ShowUI();
        if (EnterCollider == true || PlayerHp == 0)
        {
            PlayerHp -= Time.deltaTime * SetDamage;
            float calc_Health = PlayerHp / MaxHP;
            if (calc_Health <= 0)
            {
                PlayerHp = 0;
                MoveControl = false;
                Sh_GameOver.gameObject.SetActive(true);
            }
            SetHealtBar(calc_Health);
        }
        else if (PlayerHp > 0)
        {
            MoveControl = true;
            Sh_GameOver.gameObject.SetActive(false);
        }
        if (MoveControl == false)
        {
            value += Time.deltaTime * 10;
            value = Mathf.Clamp(value, 0, maxValue);
            float amount = value / maxValue;

            filled.fillAmount = amount;
            text.text = Mathf.RoundToInt(value).ToString() + "%";
            if (value == maxValue)
                Application.LoadLevel(Application.loadedLevel);
        }

        if (MoveControl == true)
        {
            Movement();
        }
        if (GetCryStal == 4)
        {
            Area.gameObject.SetActive(false);
            myAnimator.enabled = true;
            PlayerHp = 100;
        }
        if (GetCryStal > 4) GetCryStal = 4;
    }

    public void Movement()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        //bool Input_P = Input.GetButtonDown("Fire3");
        /* if (moveV > 0f)
         {
             Direction = new Vector3(0, head.transform.forward.y, 0).normalized * speed * Time.deltaTime;
             Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
             transform.Translate(Rotation * Direction);
         }
         if (moveV < 0f)
         {
             Direction = new Vector3(0, -head.transform.forward.y, 0).normalized * speed * Time.deltaTime;
             Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
             transform.Translate(Rotation * Direction);
         }
         if (moveH < 0f)
         {
             Direction = new Vector3(head.transform.forward.x, 0 , 0).normalized * speed * Time.deltaTime;
             Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
             transform.Translate(Rotation * Direction);
         }
         if (moveH > 0f)
         {
             Direction = new Vector3(-head.transform.forward.x, 0, 0).normalized * speed * Time.deltaTime;
             Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
             transform.Translate(Rotation * Direction);
         }*/

        Vector3 movement = new Vector3(-moveH,moveV,0.0f);
        rb.velocity = movement * speed;
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("p"))
        {
            Time.timeScale = 0;
            FPS.gameObject.SetActive(false);
            PauseUI.gameObject.SetActive(true);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.SetActive(false);
            GetCryStal++;
            GetTrigger = true;
            StartCoroutine(Wait_Time());
        }
        if (other.gameObject.CompareTag("Asteroid"))
        {
            // PlayerHp = PlayerHp - 10;
            EnterCollider = true;
            StartCoroutine(Wait_Time());
            SetHealtBar(PlayerHp);
        }
        if (other.gameObject.CompareTag("Deep"))
            PlayerHp = 0;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            EnterCollider = false;
        }
    }

    void ShowUI()
    {
        Sh_PlanetName.text = "" + PlanetName;
        Sh_Crystal.text = "Crystal :  " + GetCryStal.ToString() + "/ 4";
        if (GetCryStal == 4) Sh_Crystal.text = "ค้นหา warp gate";
    }
    public void SetHealtBar(float myHealth)
    {
        Sh_HealtBar.transform.localScale = new Vector3(myHealth, transform.localScale.y, transform.localScale.z);
    }
    public void GamePause(string InputBT)
    {
        if (InputBT == "Resume Game")
        {
            Time.timeScale = 1;
            FPS.gameObject.SetActive(true);
            PauseUI.gameObject.SetActive(false);
        }
        else if (InputBT == "Main Menu")
        {
            Time.timeScale = 1;
            Application.LoadLevel("Scene StartMenu");
        }
        else if (InputBT == "Select New Planet")
        {
            Time.timeScale = 1;
            FPS.gameObject.SetActive(true);
            PauseUI.gameObject.SetActive(false);
            Application.LoadLevel("Scene SpaceCraft");
        }
        else if (InputBT == "Game Exit")
            Application.Quit();
    }
    IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(2);
        print("Delay");
        GetTrigger = false;
        EnterCollider = false;
        yield break;
    }
}
