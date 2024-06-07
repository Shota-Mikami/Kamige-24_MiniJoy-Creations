using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public bool Menu_Onoff;
    public bool Menu_Onoff_Now;
    public RectTransform Menu_UI;
    public float Menu_Speed;
    public float Menu_Pos;
    public float Menu_MAXPos;
    public int Button_MAX;
    public int Button_Now;
    public Button Select_Button;
    // Start is called before the first frame update
    void Start()
    {
        Button_MAX = Menu_UI.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {        
        //===============================================================================
        //MenuÇÃåƒÇ—èoÇµ
        if (Input.GetKeyDown(KeyCode.Escape) && !Menu_Onoff&&Menu_Onoff_Now)
        {
            Menu_UI.gameObject.SetActive(true);
            Menu_Onoff = true;
            Menu_Pos = Menu_MAXPos;
            Menu_Onoff_Now=false;

            Button_Now = 0;

            Select_Button = Menu_UI.transform.GetChild(Button_Now).gameObject.GetComponent<Button>();
            Select_Button.GetComponent<Animator>().SetBool("run", true);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Menu_Onoff && Menu_Onoff_Now)
        {
            Menu_Onoff = false;
            Menu_Pos = 0;
            Menu_Onoff_Now = false;

        }

        if(Menu_Onoff) 
        {
            if (Menu_Pos <= 0.0f)
            {
                Menu_Pos = 0.0f;
                Menu_Onoff_Now = true;

            }
            else
            {
                Menu_Pos -= Menu_Speed;
                Menu_UI.anchoredPosition = new Vector3(0.0f, Menu_Pos, 0.0f);//UIÇÃà íuÇÃà⁄ìÆ
            }
        }

        else if (!Menu_Onoff) 
        {
            if (Menu_Pos >= Menu_MAXPos)
            {
                Menu_Pos = Menu_MAXPos;
                Menu_UI.gameObject.SetActive(false);

                Menu_Onoff_Now = true;
            }
            else
            {
                Menu_Pos += Menu_Speed;
                Menu_UI.anchoredPosition = new Vector3(0.0f, Menu_Pos, 0.0f);//UIÇÃà íuÇÃà⁄ìÆ
            }
        }

        //===============================================================================

        if(Menu_Onoff)
        {
            Select_Button = Menu_UI.transform.GetChild(Button_Now).gameObject.GetComponent<Button>();

            //Select_Button.image.color = Color.gray;

            if (Input.GetKeyDown("s"))
            {
                Select_Button.GetComponent<Animator>().SetBool("run", false);
                Button_Now += 1;

                if (Button_Now >= Button_MAX)
                {
                    Button_Now = 0;
                }

                Select_Button = Menu_UI.transform.GetChild(Button_Now).gameObject.GetComponent<Button>();

                Select_Button.GetComponent<Animator>().SetBool("run", true);
            }

            if (Input.GetKeyDown("w"))
            {
                Select_Button.GetComponent<Animator>().SetBool("run", false);
                Button_Now -= 1;

                if (Button_Now < 0)
                {
                    Button_Now = Button_MAX - 1;
                }
                Select_Button = Menu_UI.transform.GetChild(Button_Now).gameObject.GetComponent<Button>();

                Select_Button.GetComponent<Animator>().SetBool("run", true);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Select_Button.GetComponent<Animator>().SetTrigger("count");
                Select_Button.GetComponent<Animator>().SetBool("run", false);
                Select_Button.onClick.Invoke();
            }

        }
    }
}
