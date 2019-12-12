using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour
{
    public bool charged = false;
    public float gravityFactor = 1f;
    public bool isPlanet;

    public bool inside = false;
    public GameObject ball;
    private Rigidbody2D rigid;
    private LifesManager lifeManager;
    private LaunchManager launchManager;
    private Charge charge;


	void Start ()
    {
        GetGameObjects();
        lifeManager = GameObject.FindObjectOfType<LifesManager>();
        launchManager = GameObject.FindObjectOfType<LaunchManager>();
        charge = GameObject.FindObjectOfType<Charge>();
    }
	
	void FixedUpdate ()
    {
        //If requirments are met strong pull
        if ((inside && charged && Input.GetMouseButton(0) && !isPlanet && ball != null) || (inside && isPlanet && ball != null))
        {
            rigid.AddForce((transform.position - ball.transform.position).normalized * rigid.mass * gravityFactor / (transform.position - ball.transform.position).sqrMagnitude);
        }
        //Slight pull to the paddle constantly, tweak used to pervent stuck/boring gameplay loops
        else if (!isPlanet && launchManager.hasLaunched && ball != null)
        {
            rigid.AddForce((transform.position - ball.transform.position).normalized * rigid.mass * 5f / (transform.position - ball.transform.position).sqrMagnitude);
        }
	}

    void Update()
    {
        if(!isPlanet)
        {
            if(Charge.charge == 5)
            {
                charged = true;
            }
            else
            {
                charged = false;
            }
        }
    }

    public void GetGameObjects()
    {
        ball = GameObject.FindObjectOfType<Ball>().gameObject;
        rigid = ball.GetComponent<Rigidbody2D>();
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject == ball)
        {
            inside = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == ball)
        {
            inside = true;
        }
    }

    //Collision events for paddle
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(!isPlanet)
        {
            if(inside && charged && Input.GetMouseButton(0) && coll.gameObject == ball && Charge.charge >= 5)
            {
                Destroy(coll.gameObject);
                Charge.charge = 0;
                charge.UpdateCharges();
                lifeManager.RespawnBall();
                return;
            }
            else if (coll.gameObject == ball && ball != null &&!(Charge.charge >= 5))
            {
                Charge.charge++;
                charge.UpdateCharges();
            }
        }
    }
}
