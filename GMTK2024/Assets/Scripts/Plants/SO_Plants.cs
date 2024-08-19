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

    [SerializeField]
    int desiredWaterLevel;
    public int DesiredWaterLevel { get => desiredWaterLevel; set => desiredWaterLevel = value; }

    [SerializeField]
    int desiredSoilBracket;
    public int DesiredSoilBracket { get => desiredSoilBracket; set => desiredSoilBracket = value; }

    [SerializeField]
    List<string> goodNeighborLabels;
    public List<string> GoodNeighborLabels { get => goodNeighborLabels; private set => goodNeighborLabels = value; }

    [SerializeField]
    List<string> badNeighborLabels;
    public List<string> BadNeighborLabels { get => badNeighborLabels; private set => badNeighborLabels = value; }


    //copy this format for all base data for PLANTS
    //BASE DATA: stuff that exists from the start
    //each plant TYPE will have its own SO_Plants
    //   e.g. the Fern's DesiredSunlight is .5f, the Moss's is .1f

}
