using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float launchSpeed;
    public AudioClip launchSound;

    private LaunchManager launchManager;

    private Rigidbody2D rigid2D;
    private AudioSource sound;

    // Use this for initialization
    void Start ()
    {
        launchManager = GameObject.FindObjectOfType<LaunchManager>();
        rigid2D = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //Makes sure the ball doesn't go too fast or slow. Not 100% sure on how it works,
        //But 10f gives 100 sprMag which is equal to the 563 points of force added
        //in the launching of the ball.
        if (rigid2D.velocity.sqrMagnitude > 101f || rigid2D.velocity.sqrMagnitude < 99f)
        {
            rigid2D.velocity = rigid2D.velocity.normalized * 10f;
        }
    }

    // Update is called once per frame
    void Update ()
    {
            if (Input.GetMouseButtonUp(0) && !launchManager.hasLaunched)
            {
                launchManager.hasLaunched = true;
                AudioSource.PlayClipAtPoint(launchSound, transform.position);
                Vector2 trgect = (launchManager.target.transform.position - transform.position).normalized;
                rigid2D.AddForce(trgect * launchSpeed);
                launchManager.DestoryIndicator();
            }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(launchManager.hasLaunched && sound != null)
        {
            sound.Play();
        }
    }
}
