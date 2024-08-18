using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Plants", menuName = "ScriptableObjects/Plant")]

public class SO_Plants : SO_Decoration
{

    [SerializeField]
    string plantGenome;
    
    [SerializeField]
    List<Sprite> sprites;
    public List<Sprite> Sprites { get => sprites; private set => sprites = value; }

    [SerializeField]
    int desiredSunlight;
    public int DesiredSunlight { get => desiredSunlight; set => desiredSunlight = value; }

    //copy this format for all base data for PLANTS
    //BASE DATA: stuff that exists from the start
    //each plant TYPE will have its own SO_Plants
    //   e.g. the Fern's DesiredSunlight is .5f, the Moss's is .1f
    
}
