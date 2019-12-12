using UnityEngine;
using System.Collections;

public class PlanetForce : MonoBehaviour {
    public GameObject planet; // assign your planet GO in unity editor here
    public float gravityFactor = 1f; // then tune this value  in editor too

    private Rigidbody2D rigid;
    private bool entered = false;

    void FixedUpdate()
    {
        rigid.AddForce((planet.transform.position - transform.position).normalized * rigid.mass * gravityFactor / (planet.transform.position - transform.position).sqrMagnitude);
    }


    // Use this for initialization
    void Start ()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(entered)
        {
            print("entered");
            FixedUpdate();
        }
    }

    public void enteredFeild()
    {
        entered = true;
    }
}
