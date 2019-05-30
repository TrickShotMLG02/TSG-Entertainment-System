using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    public enum type { Nothing, RandomColor, Fade  };
    public type Selected;

    int r;
    int g;
    int b;

    bool r_p;
    bool r_m;
    bool g_p;
    bool g_m;
    bool b_p;
    bool b_m;
    bool b_p2;

    float var = 1;
    float var2 = 1;
    int counter;

    public Color Random_Color;
    public Color Fade_Color;

    // Start is called before the first frame update
    void Start()
    {
        Random_Color = new Color(Random.value, Random.value, Random.value, 1.0f);
        
        if (Selected == type.RandomColor)
        {
            this.GetComponent<Image>().color = Random_Color;
        }

        if (Selected == type.Nothing)
        {
            //Do Nothing
        }

        b_p = true;
    }


    // Update is called once per frame
    void Update()
    {
        Fade_Color = new Color(r / 255f, g / 255f, b / 255f, 1.0f);

        if (Selected == type.Fade)
        {
            this.GetComponent<Text>().color = Fade_Color;

            if(r == 255 && g == 0 && b == 255 && var == 2)
            {
                var2 = 3;
            }

            if (b_p == true && b < 255 && r == 0 && var == 1)
            {
                b = b + 1;
                
            }
            else
            {
                b_p = false;
                g_p = true;
                var = 2;
            }

            if (g_p == true && g < 255 && b == 255 && var == 2 && var2 == 1)
            {
                g = g + 1;
                
            }
            else
            {
                g_p = false;
                b_m = true;
            }

            if (b_m == true && g == 255 && b < 256 && b != 0 && r == 0)
            {
                b = b - 1;
            }
            else
            {
                b_m = false;
                r_p = true;
            }

            if (r_p == true && g == 255 && b == 0 && r < 255)
            {
                r = r + 1;
            }
            else
            {
                r_p = false;

                if(g > 0 && b == 0 && r == 255)
                {
                    g = g - 1;
                }
                else
                {
                    if(g == 0 && r == 255 && b < 255 && b >= 0 && var == 2)
                    {
                        b = b + 1;
                        var2 = 3;
                    }
                    else
                    {
                        if (r < 256 && r > 0 && b == 255 && g == 0 && var2 == 3)
                        {
                            r = r - 1;
                            var = 5;

                            counter = counter + 1;
                            if (counter == 255)
                            {
                                var2 = 5;
                                counter = 0;
                                var = 2;
                                var2 = 1;
                            }
                            
                        }
                        else
                        {
                            
                        }
                    }

                }

            }
            
        }

    }

}