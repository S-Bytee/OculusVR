using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class KeyboardVRManager : MonoBehaviour
{
    PhysicsPointer laserInstance;
    public string Text;
    string[] Exceptions = { "Shift","Space", "Backspace", "Clear", "Enter", "Cancel","Key" };
    string[] SpecialChar = { "!",":", ";", ",", "*", "$","=",")","<" };
    int x = 0;
    public GameObject WheelCanvas;
    // Start is called before the first frame update
    void Start()
    {
        laserInstance = PhysicsPointer.Instance;
    }

    private void OnEnable()
    {
        // WheelCanvas.GetComponent<Animator>().SetBool("active", true);    
        Text = "";
    }
    private void OnDisable()
    {
        Text = "";
    }
    // Update is called once per frame
    void Update()
    {
        KeyboardTyping();
    }


    void KeyboardTyping()
    {
        if(laserInstance.hit.collider)
        {
            if (laserInstance.hit.collider.transform.parent)
            {
                if (laserInstance.hit.collider.transform.parent.tag == "Keyboard")
                {
                    if (!Exceptions.Contains(laserInstance.hit.collider.name))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Text += laserInstance.hit.collider.name;
                            Debug.Log(Text);
                        }
                    }
                    else
                    {
                        switch (laserInstance.hit.collider.name)
                        {
                            case "Space":
                                {
                                    if (Input.GetMouseButtonDown(0))
                                    {
                                        Text += " ";
                                        Debug.Log(Text);

                                    }
                                    break;
                                }
                            case "Clear":
                                {
                                    if (Input.GetMouseButtonDown(0))
                                    {
                                        Text = "";
                                        Debug.Log(Text);

                                    }
                                    break;
                                }
                            case "Backspace":
                                {
                                    if (Input.GetMouseButtonDown(0))
                                    {

                                        Text = Text.Remove(Text.Length - 1, 1);
                                        Debug.Log(Text);

                                    }
                                    break;
                                }
                            case "Shift":
                                {
                                    if (Input.GetMouseButtonDown(0))
                                    {
                                        x++;

                                        if (x % 2 == 0)
                                        {
                                            SwitchToMAj(true);

                                        }
                                        else
                                        {
                                            SwitchToMAj(false);

                                        }


                                    }
                                    break;
                                }
                            case "Cancel":
                                {
                                    if (Input.GetMouseButtonDown(0))
                                    {

                                        //WheelCanvas.GetComponent<Animator>().SetBool("active", false);
                                        //WheelCanvas.GetComponent<Animator>().SetFloat("direction", -1);
                                        gameObject.SetActive(false);
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            
        }
    }


    void SwitchToMAj(bool switchTo)
    {
       
       for(int i =0; i<transform.childCount;i++)
        {
            if(!Exceptions.Contains(transform.GetChild(i).gameObject.name) )
            {
               
                if(transform.GetChild(i).childCount==2)
                {
                    
                        string min = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text;
                        string maj = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text;
                        if(switchTo)
                        {
                            
                            int n;
                            if(int.TryParse(transform.GetChild(i).name,out n) || SpecialChar.Contains(transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text))
                            {
                                if (int.TryParse(transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text, out n))
                                {
                                    //Ken name numerique donc nrodou (1 => & / 2 => é ...)
                                    transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text;
                                    transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = n + "";
                                    transform.GetChild(i).name = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text;
                                }

                                if (SpecialChar.Contains(transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text))
                                {//Ken characterSpecial
                                    string temp = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text;
                                    transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text;
                                    transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = temp;

                                    transform.GetChild(i).name = temp;

                                }


                            }
                            else
                            {
                                transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text.ToUpper();
                                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text.ToLower();
                                transform.GetChild(i).name = transform.GetChild(i).name.ToLower();

                            }

                        }
                        else
                        {
                       
                            int n;
                            if(int.TryParse(transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text,out n) || SpecialChar.Contains(transform.GetChild(i).name))
                            {
                                if(int.TryParse(transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text, out n))
                                {
                                    //Ken getchild(1) numerique donc nrodou (& => 1 / é => 2 ...)
                                    transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text;
                                    transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = n + "";
                                    transform.GetChild(i).name = n + "";
                                }

                                if(SpecialChar.Contains(transform.GetChild(i).name))
                                {//Ken characterSpecial
                                string temp = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text;
                                transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text;
                                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = temp;

                                transform.GetChild(i).name = temp;
                                
                                }
                            }
                            else
                            {
                                transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshPro>().text.ToLower();
                                transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text = transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshPro>().text.ToUpper();
                                transform.GetChild(i).name = transform.GetChild(i).name.ToUpper();
                            }

                    }

                }

            }
        }

    }



}
