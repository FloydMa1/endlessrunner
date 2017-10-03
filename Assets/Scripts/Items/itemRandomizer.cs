using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRandomizer : MonoBehaviour {

    [SerializeField]private GameObject item;

     void Start()
    {
        var random = Randomize();
        if(random >= 2)
        {
            Debug.Log("ik ben hoger dan 2");
        }else
        {
            Debug.Log("ik ben lager dan 2");
        }
    }

    float Randomize()
    {
        return Random.Range(0, 5);
    }

    void SpawnItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
