using UnityEngine;
using System.Collections;

public class Lifes : MonoBehaviour
{
    public static int lifesLeft = 3;

    private SpriteRenderer[] lifes = new SpriteRenderer[3];
    private Color normal = new Color(1f,1f,1f,1f);
    private Color transparent = new Color(1f, 1f, 1f, 0.5f);

    void Start()
    {
        //Grabs the 3 child sprites
        for (int i = 0; i <= 2; i++)
        {
            lifes[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        UpdateLifes();
    }

    //Changes sprite transparncy
    void DisplayLifes(int count)
    {
        for (int i = 0; i <= 2; i++)
        {
            if(count <=i)
            {
                lifes[i].color = transparent;
            }
            else
            {
                lifes[i].color = normal;
            }
        }
    }

    //Message to you guessed it, updatelifes. 
    public void UpdateLifes()
    {
        DisplayLifes(lifesLeft);
    }
}
