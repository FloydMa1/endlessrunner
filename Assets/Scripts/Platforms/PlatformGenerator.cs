using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject thePlatform;
    [SerializeField] private Transform generationPoint;
    [SerializeField] private float distancBetween;
    [SerializeField] private float distanceBetweenMin;
    [SerializeField] private float distanceBetweenMax;
    [SerializeField] private GameObject[] thePlatforms;
   
    private int platformSelector;
    //private float platformWidth;
    private float[] platformWidths;

    private float minHeight;
    [SerializeField]
    private Transform maxHeightPoint;
    private float maxHeight;
    [SerializeField]
    private float maxHeightChange;
    private float heightChange;

    
    private void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        
        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            print(thePlatforms[i].transform.localScale);
            platformWidths[i] = thePlatforms[i].transform.localScale.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.transform.position.y;
    }


    private void Update()
    {
        if (!(transform.position.x < generationPoint.position.x)) return;
        transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distancBetween, heightChange,
            transform.position.z);

        heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

        if(heightChange > maxHeight)
        {
            heightChange = maxHeight;
        }else if (heightChange < minHeight) {
            heightChange = minHeight;
        }

        distancBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

        platformSelector = Random.Range(0, thePlatforms.Length);
        
        Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
    }
}