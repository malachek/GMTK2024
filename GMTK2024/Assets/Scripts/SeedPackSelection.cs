using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeedPackSelection : MonoBehaviour 
{
    public int seedPackIndex;

    public void DestroyPack(){
        Destroy(gameObject);
    }
}
