using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest()
    {
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestoyed()
    {
        if(Brick.breakableCount <= 0)
        {
            LoadNextLevel();
            ResetLifesCharge();
        }
    }

    void ResetLifesCharge()
    {
        Charge.charge = 0;
        Lifes.lifesLeft = 3;

    }
}
