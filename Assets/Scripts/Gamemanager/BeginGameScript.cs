using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGameScript : MonoBehaviour {
    
	void Start () {
        Time.timeScale = 0;
	}
	
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
	}
}
