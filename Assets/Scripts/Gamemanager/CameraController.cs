using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    

    [SerializeField]
    private GameObject thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;



    void Start () {


        lastPlayerPosition = thePlayer.transform.position;
    }
	
	void Update () {

        distanceToMoveX = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y /*+ distanceToMoveY*/, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
	}
}
