using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Decoration", menuName = "ScriptableObjects/Decor")]

public class SO_Decoration : ScriptableObject
{

    [SerializeField]
    public string description;

    [SerializeField]
    Sprite sprite;
    public Sprite Sprite { get => sprite; private set => Sprite = value; }

    

}
