using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Texture snowy;
    [SerializeField]
    private Texture grassLands;
    [SerializeField]
    private Texture corruptedLands;
    private float timeLeft = 5f;

    playerMovement movement;
    [SerializeField]
    private GameObject player;
    
    private Renderer render;

	void Start () {
        movement = player.GetComponent<playerMovement>();

        render = GetComponent<Renderer>();

	}
	
	
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        render.material.mainTextureOffset = offset;

        if (movement.speedMilestoneCount > 200)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                render.material.mainTexture = snowy;
                timeLeft = 5f;
            }
        }
         if (movement.speedMilestoneCount > 1100)
        {
                render.material.mainTexture = corruptedLands;
        }

    }
}
