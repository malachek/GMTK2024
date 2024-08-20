using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducky : MonoBehaviour
{
    public WaterSpray waterSpray;
    // Start is called before the first frame update
    void Start()
    {
        waterSpray = FindObjectOfType<WaterSpray>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteract(InteractGodMode interactGodMode)
    {
        Debug.Log("spaying time");
        waterSpray.ToggleWaterTime();
    }
}
