﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

	// Use this for initialization
	void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Object Destoryed " + instance);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
