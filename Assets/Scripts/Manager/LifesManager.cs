using UnityEngine;
using System.Collections;

public class LifesManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject direction;

    private Lifes lifes;
    private LevelManager levelManager;
    private LaunchManager launchManger;
    private Charge charge;

    void Awake()
    {
        lifes = GameObject.FindObjectOfType<Lifes>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        launchManger = GameObject.FindObjectOfType<LaunchManager>();
        charge = GameObject.FindObjectOfType<Charge>();
    }


    public void LoseLife()
    {
        Lifes.lifesLeft--;        
        if(Lifes.lifesLeft == -1)
        {
            levelManager.LoadLevel("Lose Screen");
            return;
        }
        lifes.UpdateLifes();
    }

    public void RespawnBall()
    {
        Charge.charge = 0;
        charge.UpdateCharges();
        Instantiate(ball);
        Instantiate(direction);
        launchManger.GetGameObjects();
        launchManger.hasLaunched = false;
    }
}
