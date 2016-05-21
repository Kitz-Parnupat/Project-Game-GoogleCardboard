using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public string PlanetName;
    public float PlayerHp,MaxHP;
    public int GetCryStal;
    public float T_speed, R_speed,JumpCount, JumpThrust;
    public bool MoveControl = true;
    public float SetDamage;
    // Input Button
    private float Input_H, Input_V;
    private bool Input_J,Input_P; // J = jump P = pause
    public bool IsGrounded;
    int count;
   
    //*******
    CardboardHead head = null;
    Animator anim;
    Rigidbody rb;
    Vector3 Direction;
    Quaternion Rotation;
    //*******UI 
    public Text Sh_Crystal,Sh_PlanetName;
    public GameObject Sh_HealtBar, Sh_GameOver;
    public bool EnterCollider;
    //**** Cooldown ****/
    public Image filled;
    public Text text;
    public float maxValue = 100;
    public float value = 0;
    public GameObject FPS;
    public GameObject PauseUI;
    public bool GetTrigger;
    //*** audio
    float SoundRate = 0.65f,NextSound;
    void Start () {        
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        head = Camera.main.GetComponent<StereoController>().Head;
        FPS.gameObject.SetActive(true);
        PauseUI.gameObject.SetActive(false);
        //MoveControl = true;
        PlayerHp = MaxHP;
        GetCryStal = 0;
        ShowUI();
	}
	
	void FixedUpdate () {
        GetInput();
        ShowUI();
        if (GetTrigger == true) print("GetTrigger ON");
        
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
    }

    void GetInput()
    {
        Input_H = Input.GetAxis("Horizontal");
        Input_V = Input.GetAxis("Vertical");
        Input_J = Input.GetButtonDown("Jump");
        Input_P = Input.GetButtonDown("Fire3");
        if (Input.GetButtonDown("Jump")) Input_J = true;
        else Input_J = false;
        if (MoveControl == true)
        {
            Movement();
        }
        SetAnimator();
    }
    void Movement()
    {
            // เคลือนที่ ไปหน้าและ ถ่อยหลัง 
            if (Input_V > 0f) // ไปหน้า
            {
                Direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * T_speed * Time.deltaTime;
                Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
                transform.Translate(Rotation * Direction);
                footStepAudio();
            }
            else if (Input_V > 0f && Input_H != 0)
            {
                Direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * T_speed * Time.deltaTime;
                Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
                transform.Translate(Rotation * Direction);
                footStepAudio();

            }
            else if (Input_V < 0f) // ถ่อยหลัง
            {
                Direction = new Vector3(-head.transform.forward.x, 0, -head.transform.forward.z).normalized * T_speed * Time.deltaTime;
                Rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));

                transform.Translate(Rotation * Direction);
                footStepAudio();
            }
            // *******
            if (Input_J == true && IsGrounded == true)
            {
                rb.AddForce(Vector3.up * JumpThrust, ForceMode.VelocityChange);
                JumpCount++;
            }
            if (IsGrounded == false && JumpCount > 0 && JumpCount < 2)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector3.up * JumpThrust, ForceMode.VelocityChange);
                    JumpCount++;
                }
                if (IsGrounded == false && JumpCount >= 2)
                {
                    if (Input.GetButtonDown("Jump")) return;
                }
            }
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown("p"))
        {
            Time.timeScale = 0;
            FPS.gameObject.SetActive(false);
            PauseUI.gameObject.SetActive(true);

        }
        if (Input_H != 0)
        {
            transform.Rotate(new Vector3(0, Input_H, 0) * R_speed * Time.deltaTime);
        }
    }
    void footStepAudio()
    {
        if(Time.time >= NextSound && IsGrounded == true)
        {
            NextSound = Time.time + SoundRate;
            GetComponent<AudioSource>().Play();
        }
            }
    void SetAnimator()
    {
        
        if (Input_V > 0f || Input_V < 0f) anim.SetBool("IsWalk", true);
        else  if (Input_V == 0f || Input_V < 1f) anim.SetBool("IsWalk", false);
        if (Input_H > 0f)
        {
            anim.SetBool("TurnRight", true);
        }
        if (Input_H < 0f)
        {
            anim.SetBool("TurnLeft", true);
        }
        if (Input_J == true)
        {
            anim.SetBool("Jump", true);
        }
        if (IsGrounded == false)
        {
            anim.SetBool("Falling", true);
            anim.SetBool("Landing", true);
        }
        if (PlayerHp <= 0)
        {
            anim.SetBool("Death", true);
        }
        else {
            anim.SetBool("TurnRight", false);
           // anim.SetBool("IsWalk", false);
            anim.SetBool("TurnLeft", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Falling", false);
        }
    }
    // Physic Function
    void OnTriggerEnter(Collider other) // เข้าไปใน พื้นที่ 
    {
        if (other.gameObject.CompareTag("WarpGate"))
            MoveControl = false;
        if (other.gameObject.CompareTag("Box"))
        {
            other.gameObject.SetActive(false);
            GetCryStal++;
            GetTrigger = true;
            StartCoroutine(Wait_Time());
        }
        if (other.gameObject.CompareTag("Gas"))
        {
            EnterCollider = true;
        }
        if (other.gameObject.CompareTag("Deep"))
            PlayerHp = 0;
    }
    void OnTriggerExit(Collider other) // ออกจากพื้นที่
    {
        if (other.gameObject.CompareTag("WarpGate"))
            print("Exit Warp");
        if (other.gameObject.CompareTag("Box"))
            print("Exit box ");
        if (other.gameObject.CompareTag("Gas"))
            EnterCollider = false;
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        anim.SetBool("Jump", false);
        IsGrounded = true;
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        anim.SetBool("Jump", true);
        IsGrounded = false;
    }
    // END Physic 
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
    public void Report(bool Movemet) //Report To GameController
    {
        MoveControl = Movemet;
        /*    public string PlanetName;
               public float PlayerHp;
                public int GetCryStal;*/
    }

    IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(2);
        print("Delay");
        GetTrigger = false;
        yield break;
    }
}
