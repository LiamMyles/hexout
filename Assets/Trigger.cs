using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        print("entered feild");
        col.GetComponent<PlanetForce>().enteredFeild();
    }
}
