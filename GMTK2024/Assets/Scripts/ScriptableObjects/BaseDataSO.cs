using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BaseDataSO")]
public class BaseDataSO : ScriptableObject {
    
    [Header("Base Fields")] 
    public string objectsName;
    public string objectsDescription;
    public Sprite Sprite;
    public int stackMax;
    public EItemType eItemType;
}
