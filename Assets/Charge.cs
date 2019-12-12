using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour
{
    public static int charge = 0;

    private ParticleSystem particle;
    private ParticleSystem paddleParticals;

    private SpriteRenderer[] charges = new SpriteRenderer[5];
    private Color blue = new Color(0.353f, 0.573f, 1.000f, 1f);
    private Color red = new Color(0.608f, 0.075f, 0.204f, 1f);

    void Start()
    {
        //Grabs the 5 child sprites
        for (int i = 0; i <= 4; i++)
        {
            charges[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        paddleParticals = GameObject.FindGameObjectWithTag("Paddle").GetComponent<ParticleSystem>();
        particle = gameObject.GetComponent<ParticleSystem>();
        UpdateCharges();
    }

    //Changes sprite color
    void DisplayCharges(int count)
    {
        for (int i = 0; i <= 4; i++)
        {
            if (count <= i)
            {
                charges[i].color = red;
            }
            else
            {
                charges[i].color = blue;
            }
        }
    }

    public void UpdateCharges()
    {
        if (charge <= 4)
        {
            DisplayCharges(charge);
            paddleParticals.Stop();
            particle.Stop();
        }
        else
        {
            DisplayCharges(charge);
            paddleParticals.Play();
            particle.Play();
        }
    }
}
