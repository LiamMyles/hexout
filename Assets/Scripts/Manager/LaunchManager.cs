using UnityEngine;
using System.Collections;

public class LaunchManager : MonoBehaviour
{
    public bool hasLaunched = false;

    public GameObject target;

    private GameObject ball;
    private GameObject paddle;
    private GameObject direction;

    private GravityWell[] wells;

    void Awake()
    {
        GetGameObjects();
    }

    void Update()
    {
        if(!hasLaunched)
        {
            if (ball != null)
            {
                LaunchDirection(ball);
                LockToPaddle(ball);
            }
            if(direction != null)
            {
                LaunchDirection(direction);
                LockToPaddle(direction);
            }
        }
    }

    public void GetGameObjects()
    {
        ball = GameObject.FindObjectOfType<Ball>().gameObject;
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        direction = GameObject.FindGameObjectWithTag("Direction");
        target = direction.transform.GetChild(0).gameObject;
        wells = GameObject.FindObjectsOfType<GravityWell>();
        foreach(GravityWell well in wells)
        {
            well.GetGameObjects();
        }
    }

    public void DestoryIndicator()
    {
        GameObject.Destroy(direction);
    }

    //Requires the roated object to have the script HoldRotateDirection
    void LaunchDirection(GameObject toRoate)
    {
        float rate = 1.5f;
        float angle = toRoate.transform.rotation.eulerAngles.z;
        HoldRotateDirection roate = toRoate.GetComponent<HoldRotateDirection>();

        if (angle >= 160)
        {
            roate.clockwise = true;
        }
        else if (angle <= 20)
        {
            roate.clockwise = false;
        }

        if (roate.clockwise)
        {
            toRoate.transform.Rotate(0, 0, rate * -1, Space.Self);
        }
        else if (!roate.clockwise)
        {
            toRoate.transform.Rotate(0, 0, rate, Space.Self);
        }
    }

    void LockToPaddle(GameObject toLock)
    {
        Vector3 paddlePos = paddle.transform.position;
        Vector3 offset = new Vector3(0f, 0.5f, 0f);

        toLock.transform.position = paddlePos + offset;
    }
}
