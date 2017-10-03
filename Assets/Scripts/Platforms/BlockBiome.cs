using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BlockBiome : MonoBehaviour
{
    public static Sprite blockSprite;
    public static Sprite rightsideBlock;
    public static Sprite leftsideBlock;

    [SerializeField] private Blahblah blockSide = Blahblah.Middle;

    enum Blahblah
    {
        Middle,
        Left,
        Right
    };

    void Start()
    {
        if (blockSprite == null) return;

        var renderer = GetComponent<SpriteRenderer>();

        switch (blockSide)
        {
            case Blahblah.Middle:
                renderer.sprite = blockSprite;
                break;
            case Blahblah.Left:
                renderer.sprite = leftsideBlock;
                break;
            case Blahblah.Right:
                renderer.sprite = rightsideBlock;
                break;
        }
    }

    public static void SetBlockSprite(Biome biome)
    {
        blockSprite = biome.middleBlock;
        rightsideBlock = biome.rightBlock;
        leftsideBlock = biome.leftBlock;
    }
}