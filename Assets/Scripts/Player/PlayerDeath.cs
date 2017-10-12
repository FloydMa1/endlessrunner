using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public Canvas DeathCanvas;

    private void Start()
    {
        DeathCanvas = GameObject.Find("DeathCanvas").GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("moan");
            Time.timeScale = 0f;
            DeathCanvas.enabled = true;
        }
    }
}
