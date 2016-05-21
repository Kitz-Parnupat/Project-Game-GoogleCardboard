using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Control_QuizeV5 : MonoBehaviour {
    // Set text 
    public Text Text_Head, Text_NO_select, Text_Plannet_name, Text_NO;
    public Text Text_Btn1, Text_Btn2, Text_Btn3, Text_Btn4;
    public Text Text_Score, Text_Score_sum;
    // Set tring Text 
    public string Head, planet, NO_select;
    public string Btn1, Btn2, Btn3, Btn4;
    private int Count_Choice,Btn_Choice,Score;

    // GameObject 
    public GameObject buttonNext;
    public GameObject firstbuttonSelect;
    public Color newColor, DefaulColor;
    public Button buttonCh1, buttonCh2, buttonCh3, buttonCh4;
    public GameObject Question,No_ch,Ans_Sum;
    //คำตอบที่ถูก
    int[][] answer_Chack = new int[][]  //เรียงตามข้อ
    {
        new int[] {2,1,3,1}, // ดาวพุธ
        new int[] {4,3,2,1},// ดาวศุกร์
        new int[] {1,2,3,4},// ดาวโลก
        new int[] {2,3,2,4},// ดาวอังคาร
        new int[] {2,3,2,4},// ดาวพฤสับดี
        new int[] {3,4,3,4},// ดาวเสาร์
        new int[] {3,3,2,3},// ดาวยูเรนัส
        new int[] {3,3,3,2},// ดาวเนปจูน
        new int[] {4,1,3,2}// ดาวอาทิตย์
    };


    // Use this for initialization
    void Start () {
        
        Count_Choice = 1;
        Score = 0;
        CheckAnser();
        //PlayerPrefs.SetString("Name_planet_q", "Mercury");
        planet = PlayerPrefs.GetString("Name_planet_q");
        
    }
	
	// Update is called once per frame
	void Update () {
        ShowTextOnUI();
        SetText();
        
    }
    void ShowTextOnUI()
    {
        // CheckAnser();
        Text_Plannet_name.text = planet.ToString();
        Text_Head.text = "\n" + Head;
        if(Count_Choice > 4)
        {
            Text_NO.text = "4/4";
            Question.gameObject.SetActive(false);
            Ans_Sum.gameObject.SetActive(true);
        }
        else
        {
            Text_NO.text = Count_Choice.ToString()+"/4";
            Question.gameObject.SetActive(true);
            Ans_Sum.gameObject.SetActive(false);
        }
        
        Text_Btn1.text = "" + Btn1;
        Text_Btn2.text = "" + Btn2;
        Text_Btn3.text = "" + Btn3;
        Text_Btn4.text = "" + Btn4;
    }

    public void InputBtnHead(bool status) 
    {
         if (status == true)
        {
            if (Btn_Choice != 0) //เปลี่ยนวิธีการคิดด้วย
            { 
                CheckAnser();
                
                Count_Choice++;
                Btn_Choice = 0;
                SetButtonColor();
            }
            else
            {
                No_ch.gameObject.SetActive(true);
            }
        }
        SetfirstSelect();
    }
    public void InputBtnChoice(int Choice)
    {
        Btn_Choice = Choice;
        SetfirstSelect();
        SetButtonColor();
        No_ch.gameObject.SetActive(false);//เอาไม่เลือกออก
    }
    void SetText()
    {
        if (planet == "Sun")
        {
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "ภายในแก่นดวงอาทิตย์เกิดปฏิกิริยานิวเคลียร์ ฟิวชัน คิดเป็นการเปลียนมวลประมาณเท่าไร";
                        Btn1 = "1 ล้านตัน";
                        Btn2 = "2 ล้านตัน";
                        Btn3 = "3 ล้านตัน";
                        Btn4 = "4 ล้านตัน";
                        break;
                    }

                case 2:
                    {
                        Head = "เส้นศูนย์สูตรดวงอาทิตย์ใช้เวลาหมุนรอบตัวเองประมาณกี่วัน";
                        Btn1 = "25 วัน";
                        Btn2 = "33 วัน";
                        Btn3 = "45 วัน";
                        Btn4 = "53 วัน";
                        break;
                    }

                case 3:
                    {
                        Head = "เส้นผ่านศูนย์กลางของดวงอาทิตย์เป็นกี่เท่าของโลก";
                        Btn1 = "79 เท่าของโลก";
                        Btn2 = "97 เท่าของโลก";
                        Btn3 = "109 เท่าของโลก";
                        Btn4 = "129 เท่าของโลก";
                        break;
                    }
                case 4:
                    {
                        Head = "ดวงอาทิตย์มีองค์ประกอบเป็นอะไร";
                        Btn1 = "หิน";
                        Btn2 = "แก็ส";
                        Btn3 = "ก๊าซ";
                        Btn4 = "สะสาร";
                        break;
                    }
            }
        }

        if (planet == "Mercury")
        {
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวพุธเป็นเวลาเท่าไร";
                        Btn1 = "59  วัน";
                        Btn2 = "88  วัน";
                        Btn3 = "160  วัน";
                        Btn4 = "260  วัน";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองของดาวพุธเป็นเวลาเท่าไร";
                        Btn1 = "59  วัน";
                        Btn2 = "80  วัน";
                        Btn3 = "120  วัน";
                        Btn4 = "160  วัน";
                        break;
                    }

                case 3:
                    {
                        Head = "พื้นพิวของดาวพุธเต็มไปด้วยอะไร";
                        Btn1 = "น้ำ";
                        Btn2 = "ลาวา";
                        Btn3 = "หลุมอุกกาบาต";
                        Btn4 = "แก๊ซ";
                        break;
                    }
                case 4:
                    {
                        Head = "ดาวพุธมีส่วนประกอบหลักเป็นอะไร";
                        Btn1 = "โลหะ";
                        Btn2 = "ซิลิเกต";
                        Btn3 = "ซิลิก้อน";
                        Btn4 = "หินแข็ง";
                        break;
                    }
            }
        }

        if (planet == "Venus")
        {
            //ดาวศุกร์
            switch (Count_Choice)
                {
                    case 1:
                        {
                            Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวศุกร์เป็นเวลาเท่าไร";
                            Btn1 = "50  วัน";
                            Btn2 = "88  วัน";
                            Btn3 = "160  วัน";
                            Btn4 = "260  วัน";
                            break;
                        }

                    case 2:
                        {
                            Head = "คาบเวลาการหมุนรอบตัวเองดาวศุกร์เป็นเวลาเท่าไร";
                            Btn1 = "159  วัน";
                            Btn2 = "221  วัน";
                            Btn3 = "243  วัน";
                            Btn4 = "259  วัน";
                            break;
                        }

                    case 3:
                        {
                            Head = "ดาวศุกร์เอียงทำมุมเท่าไร";
                            Btn1 = "90";
                            Btn2 = "177";
                            Btn3 = "199";
                            Btn4 = "230";
                            break;
                        }
                    case 4:
                        {
                            Head = "ชั้นบรรยากาศที่มีความหนาแน่นสูงและเต็มไปด้วยแก๊สอะไร";
                            Btn1 = "แก๊สคาร์บอนไดออกไซด์";
                            Btn2 = "แก๊สมีเทน";
                            Btn3 = "แก๊สโซลีน";
                            Btn4 = "แก๊สฮีเลี่ยม";
                            break;
                        }
                }
        }
        if (planet == "Earth")
        {
            //ดาวโลก
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "ชั้นบรรยากาศที่มีความหนาแน่นสูงและเต็มไปด้วยแก๊สอะไร";
                        Btn1 = "แก๊สคาร์บอนไดออกไซด์";
                        Btn2 = "แก๊สมีเทน";
                        Btn3 = "แก๊สโซลีน";
                        Btn4 = "แก๊สฮีเลี่ยม";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองโลกเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "13 ชั่วโมง 56 นาที";
                        Btn2 = "23 ชั่วโมง 56 นาที";
                        Btn3 = "23 ชั่วโมง 59 นาที";
                        Btn4 = "22 ชั่วโมง 59 นาที";
                        break;
                    }

                case 3:
                    {
                        Head = "โลกนั้นถือกำเนิดมาเป็นเวลาเท่าไร";
                        Btn1 = "3.54 พันล้านปี";
                        Btn2 = "4.45 พันล้านปี ";
                        Btn3 = "4.54 พันล้านปี";
                        Btn4 = "5.54 พันล้านปี";
                        break;
                    }
                case 4:
                    {
                        Head = "โลกห่อหุ้มไปด้วยชั้นบรรยากาศที่มีความหนาหลายร้อยกิโลเมตร โดยประกอบไปด้วยแก๊สมากที่สุด";
                        Btn1 = "แก๊สคาร์บอนไดออกไซด์";
                        Btn2 = "แก๊สมีเทน";
                        Btn3 = "แก๊สโซลีน";
                        Btn4 = "แก๊สไนโตรเจน";
                        break;
                    }
            }
        }
        if (planet == "Mars")
        {
            //ดาวอังคาร
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวอังคารเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "366 วัน";
                        Btn2 = "478  วัน";
                        Btn3 = "678  วัน ";
                        Btn4 = "768  วัน";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองดาวอังคารเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "22.63 ชั่วโมง";
                        Btn2 = "23.63 ชั่วโมง";
                        Btn3 = "24.63 ชั่วโมง";
                        Btn4 = "25.63 ชั่วโมง";
                        break;
                    }

                case 3:
                    {
                        Head = "ชั้นบรรยากาศของดาวอังคารจะประกอบด้วยแก๊สอะไร";
                        Btn1 = "22 องศา";
                        Btn2 = "23 องศา";
                        Btn3 = "24 องศา";
                        Btn4 = "25 องศา";
                        break;
                    }
                case 4:
                    {
                        Head = "ชั้นบรรยากาศของดาวอังคารจะประกอบด้วยแก๊สอะไร";
                        Btn1 = "แก๊สคาร์บอนไดออกไซด์";
                        Btn2 = "แก๊สมีเทน";
                        Btn3 = "แก๊สโซลีน";
                        Btn4 = "แก๊สไนโตรเจน";
                        break;
                    }
            }
        }
        if (planet == "Jupiter")
        {
            //ดาวพฤสับดี
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวพฤสับดีเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "4,329 วัน";
                        Btn2 = "4,331 วัน";
                        Btn3 = "4,498 วัน ";
                        Btn4 = "4,578 วัน";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองดาวพฤสับดีเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "7.33 ชั่วโมง";
                        Btn2 = "8.93 ชั่วโมง";
                        Btn3 = "9.93 ชั่วโมง";
                        Btn4 = "10.93 ชั่วโมง";
                        break;
                    }

                case 3:
                    {
                        Head = "ลักษณะเด่นของดาวพฤหัสบดีคืออะไร";
                        Btn1 = "ลมที่แรงที่สุด";
                        Btn2 = "จุดแดงใหญ่";
                        Btn3 = "มีน้ำ";
                        Btn4 = "วงแหวน";
                        break;
                    }
                case 4:
                    {
                        Head = "ดาวพฤหัสบดีมีแกนหมุนเอียง";
                        Btn1 = "1.1 องศา";
                        Btn2 = "2.7 องศา";
                        Btn3 = "2.9 องศา";
                        Btn4 = "3.1 องศา";
                        break;
                    }
            }
        }
        if (planet == "Saturn")
        {
            //ดาวเสาร
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวเสาร์เป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "8,832 วัน";
                        Btn2 = "9,832 วัน";
                        Btn3 = "10,832 วัน";
                        Btn4 = "11,832 วัน";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองดาวเสาร์เป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "7.33 ชั่วโมง";
                        Btn2 = "8.93 ชั่วโมง";
                        Btn3 = "9.93 ชั่วโมง";
                        Btn4 = "10.66 ชั่วโมง";
                        break;
                    }

                case 3:
                    {
                        Head = "ความหนาแน่นน้อยกว่าดาวเสาร์น้อยกว่าอะไร";
                        Btn1 = "หิน";
                        Btn2 = "ดิน";
                        Btn3 = "น้ำ";
                        Btn4 = "อากศ";
                        break;
                    }
                case 4:
                    {
                        Head = "ลักษณะเด่นของดาวเสาร์";
                        Btn1 = "วงแหวน";
                        Btn2 = "มีน้ำ";
                        Btn3 = "ลมที่แรงที่สุด";
                        Btn4 = "ฝนดาวตก";
                        break;
                    }
            }
        }
        if (planet == "Uranus")
        {
            //ดาวยูเรนัส
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "ลักษณะเด่นของดาวยูเรนัส";
                        Btn1 = "วงแหวน";
                        Btn2 = "มีน้ำ";
                        Btn3 = "ลมที่แรงที่สุด";
                        Btn4 = "ฝนดาวตก";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองดาวยูเรนัสเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "10.24 ชั่วโมง";
                        Btn2 = "13.24 ชั่วโมง";
                        Btn3 = "17.24 ชั่วโมง";
                        Btn4 = "20.24 ชั่วโมง ";
                        break;
                    }

                case 3:
                    {
                        Head = "วิลเลียม เฮอร์เซล ค้นพบดาวยูเรนัส เมือปี พ.ศ. ใด";
                        Btn1 = "พ.ศ. 2225";
                        Btn2 = "พ.ศ. 2325";
                        Btn3 = "พ.ศ. 2425";
                        Btn4 = "พ.ศ. 2525";
                        break;
                    }
                case 4:
                    {
                        Head = "ดาวยูเรนัสีมีแกนหมุนเอียง";
                        Btn1 = "78 องศา";
                        Btn2 = "88 องศา";
                        Btn3 = "98 องศา";
                        Btn4 = "108 องศา";
                        break;
                    }
            }
        }
        if (planet == "Neptune")
        {
            //ดาวเนปจูน
            switch (Count_Choice)
            {
                case 1:
                    {
                        Head = "คาบเวลาการโคจรรอบดวงอาทิตย์ของดาวเนปจูนเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "40,190 วัน";
                        Btn2 = "50,190 วัน";
                        Btn3 = "60,190 วัน";
                        Btn4 = "70,190 วัน";
                        break;
                    }

                case 2:
                    {
                        Head = "คาบเวลาการหมุนรอบตัวเองดาวเนปจูนเป็นเวลาโดยประมาณเท่าไร";
                        Btn1 = "10.24 ชั่วโมง";
                        Btn2 = "13.24 ชั่วโมง";
                        Btn3 = "16.11 ชั่วโมง";
                        Btn4 = "20.24 ชั่วโมง ";
                        break;
                    }

                case 3:
                    {
                        Head = "ดาวเนปจูนเป็นดาวที่มีอะไรด่น";
                        Btn1 = "วงแหวน";
                        Btn2 = "มีน้ำ";
                        Btn3 = "ลมที่แรงที่สุด";
                        Btn4 = "ฝนดาวตก";
                        break;
                    }
                case 4:
                    {
                        Head = "ดาวยูเรนัสีมีแกนหมุนเอียง";
                        Btn1 = "25.3 องศา";
                        Btn2 = "28.3 องศา";
                        Btn3 = "35.3 องศา";
                        Btn4 = "40.3 องศา";
                        break;
                    }
            }
        }
    }
    IEnumerator nextScene()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Scene SpaceCraft");
        print(Time.time);
    }
    void CheckAnser()  //เอาปีกกาออก
    {
        if(Count_Choice > 3)
            StartCoroutine(nextScene());
        if (planet == "Mercury")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[0][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[0][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[0][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[0][3])
                Score++;
            if(Score >2)
                PlayerPrefs.SetInt("Mercury_Score", Score);
        }
        if (planet == "Venus")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[1][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[1][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[1][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[1][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Venus_Score", Score);
        }
        if (planet == "Earth")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[2][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[2][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[2][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[2][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Earth_Score", Score);
        }
        if (planet == "Mars")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[3][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[3][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[3][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[3][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Mars_Score", Score);
        }
        if (planet == "Jupiter")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[4][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[4][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[4][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[4][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Jupiter_Score", Score);
        }
        if (planet == "Saturn")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[5][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[5][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[5][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[5][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Saturn_Score", Score);
        }
        if (planet == "Uranus")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[6][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[6][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[6][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[6][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Uranus_Score", Score);
        }
        if (planet == "Neptune")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[7][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[7][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[7][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[7][3])
                Score++;
            if (Score > 2)
                PlayerPrefs.SetInt("Neptune_Score", Score);
        }
        if (planet == "Sun")
        {
            if (Count_Choice == 1 && Btn_Choice == answer_Chack[8][0])
                Score++;
            if (Count_Choice == 2 && Btn_Choice == answer_Chack[8][1])
                Score++;
            if (Count_Choice == 3 && Btn_Choice == answer_Chack[8][2])
                Score++;
            if (Count_Choice == 4 && Btn_Choice == answer_Chack[8][3])
                Score++;
        }
        //planet = ""; // คืนค่าตัวแปร
        Text_Score.text = Score.ToString();
        Text_Score_sum.text= Score.ToString();
    }
    public void SetfirstSelect()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        if(Btn_Choice !=0)
        {
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(buttonNext);
        } else
        {
            myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(firstbuttonSelect);
        }
    }
    public void  SetButtonColor()
    {
        switch (Btn_Choice)
        {
            case 1:
                { 
                    var cb = buttonCh1.colors;  
                    cb.normalColor = newColor;
                    buttonCh1.colors = cb;
                    break;
                }
            case 2:
                {
                    var cb = buttonCh2.colors;
                    cb.normalColor = newColor;
                    buttonCh2.colors = cb;
                    break;
                }
                
            case 3:
                {
                    var cb = buttonCh3.colors;
                    cb.normalColor = newColor;
                    buttonCh3.colors = cb;
                    break;
                }
                
            case 4:
                {
                    var cb = buttonCh4.colors;
                    cb.normalColor = newColor;
                    buttonCh4.colors = cb;
                    break;
                }
         }
        ClearButtonColor();
    }
    void ClearButtonColor()
    {
       switch (Btn_Choice)
        {
            case 1:
                {
                    var cb = buttonCh2.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh2.colors = cb;

                    cb = buttonCh3.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh3.colors = cb;

                    cb = buttonCh4.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh4.colors = cb;
                    break;
                }
            case 2:
                {
                    var cb = buttonCh1.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh1.colors = cb;

                    cb = buttonCh3.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh3.colors = cb;

                    cb = buttonCh4.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh4.colors = cb;
                    break;
                }
                
            case 3:
                {
                    var cb = buttonCh1.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh1.colors = cb;

                    cb = buttonCh2.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh2.colors = cb;

                    cb = buttonCh4.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh4.colors = cb;
                    break;
                }
                
            case 4:
                {
                    var cb = buttonCh1.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh1.colors = cb;

                    cb = buttonCh2.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh2.colors = cb;

                    cb = buttonCh3.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh3.colors = cb;
                    break;
                }
            default:
                {
                    var cb = buttonCh1.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh1.colors = cb;

                    cb = buttonCh2.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh2.colors = cb;

                    cb = buttonCh3.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh3.colors = cb;

                    cb = buttonCh4.colors;
                    cb.normalColor = DefaulColor;
                    buttonCh4.colors = cb;
                    break;
                }
           }
    }
    
}