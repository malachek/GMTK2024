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

}
