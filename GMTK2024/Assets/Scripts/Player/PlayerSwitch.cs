using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GodController godController;
    public SmallController smallController;

    public bool godIsActive = true;

   

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            godIsActive = !godIsActive;
        }
    }
}
