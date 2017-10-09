using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject thePlatform;
    [SerializeField] private Biome stoneBiome, castleBiome, corruptionBiome, snowDirtBiome;
    [SerializeField] private Transform generationPoint;

    [SerializeField] private float distancBetween;
    [SerializeField] private float distanceBetweenMin;
    [SerializeField] private float distanceBetweenMax;

    [SerializeField]private GameObject player;
    playerMovement movement;

    [SerializeField] private GameObject[] thePlatformsGrass;
   
    private int platformSelector;
    private Platforms[] platforms;

    private float minHeight;
    [SerializeField]
    private Transform maxHeightPoint;
    private float maxHeight;
    [SerializeField]
    private float maxHeightChange;
    private float heightChange;

    
    [SerializeField]
    private float randomSpike;
    [SerializeField]
    private GameObject spike;
    
    
    private void Start()
    {
        movement = player.GetComponent<playerMovement>();


        platforms = new Platforms[thePlatformsGrass.Length];

        for (int i = 0; i < thePlatformsGrass.Length; i++)
        {
            print(thePlatformsGrass[i].transform.localScale);
            platforms[i].width = thePlatformsGrass[i].GetComponent<BoxCollider2D>().size.x;
            platforms[i].platform = thePlatformsGrass[i];
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.transform.position.y;
    }


    private void Update()
    {
        if (!(transform.position.x < generationPoint.position.x)) return;
        transform.position = new Vector3(transform.position.x + platforms[platformSelector].width + distancBetween, heightChange,
            transform.position.z);

        if (movement.speedMilestoneCount > 200)
            BlockBiome.SetBlockSprite(snowDirtBiome);
        if (movement.speedMilestoneCount > 400)
            BlockBiome.SetBlockSprite(stoneBiome);
        if (movement.speedMilestoneCount > 700)
            BlockBiome.SetBlockSprite(castleBiome);
        if (movement.speedMilestoneCount > 1100)
            BlockBiome.SetBlockSprite(corruptionBiome);

        heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

        if (heightChange > maxHeight)
        {
            heightChange = maxHeight;
        } else if (heightChange < minHeight) {
            heightChange = minHeight;
        }

        
        if(Random.Range(0f, 100f) < randomSpike)
        {
            float spikeXPosition = Random.Range(-platforms[platformSelector].width / 2 + 1, platforms[platformSelector].width / 2 - 1);

            Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

            Instantiate(spike, transform.position + spikePosition, Quaternion.identity);
        }
        

        distancBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

        Debug.Log(movement.speedMilestoneCount);
        
        platformSelector = Random.Range(0, thePlatformsGrass.Length);
        Instantiate(thePlatformsGrass[platformSelector], transform.position, transform.rotation);
        
    }
}

struct Platforms
{
    public GameObject platform;
    public float width;
}

[System.Serializable]
struct Biome
{
    [SerializeField]
    public Sprite middleBlock, leftBlock, rightBlock;

}