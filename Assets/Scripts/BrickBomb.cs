using UnityEngine;
using System.Collections;

public class BrickBomb : MonoBehaviour
{
    public GameObject[] inBlastRange;
    

    public void Trigger()
    {
        print("triggered");
        foreach(GameObject element in inBlastRange)
        {
            print("First Loop");
            if (element != null)
            {
                print("Killed");
                element.GetComponent<Brick>().InstantDestory();
            }
        }
    }
}
