using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public TimeManager timeGod;

    // Start is called before the first frame update
    void Start()
    {
        timeGod = FindObjectOfType<TimeManager>();
    }


    public void OnInteract(InteractGodMode interactGodMode)
    {
        Debug.Log("new day");
        timeGod.StartNewDay();
    }
}
