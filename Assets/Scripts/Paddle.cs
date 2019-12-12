using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;

    private Vector3 paddlePos;
    private Ball ball;

    void Start()
    {
        GetGameObjects();
    }

    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void GetGameObjects()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void MoveWithMouse()
    {
        paddlePos = new Vector3(0.5f, transform.position.y, 0f);    
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
        transform.position = paddlePos;
    }

    void AutoPlay()
    {
        paddlePos = new Vector3(0.5f, transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1f, 15f);
        this.transform.position = paddlePos;
    }
}
