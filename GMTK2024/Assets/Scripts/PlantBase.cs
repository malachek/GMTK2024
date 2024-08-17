using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : DecorationBase
{
    List<Sprite> SpriteList;
    private SO_Plants plantData;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteList = plantData.Sprites;
        spriteRenderer.sprite = plantData.Sprite;
    }

    protected override void Update()
    {
        
    }
}
