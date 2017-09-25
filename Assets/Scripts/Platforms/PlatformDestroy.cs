using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour {

    [SerializeField]
    private GameObject platformDestroyPoint;

    private void Start()
    {
        platformDestroyPoint = GameObject.Find("PlatformDestroyPoint");
    }

    private void Update () {
		if(transform.position.x < platformDestroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
    
    
}
