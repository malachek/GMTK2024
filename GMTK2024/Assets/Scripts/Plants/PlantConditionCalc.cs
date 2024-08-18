using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public static class PlantConditionCalc
{
    
    /*
     * STATIC CLASS!!!!!!!!!!!!
     * 
     * this is not on a game object, it exists as a functional program script
     *  you give it a number, it gives one back
     * 
     * it does NOT store data
     *  besides the data it's initialized with
     */

    public static int maxSunPoints = 2;
    public static int maxWaterPoints = 10;
    public static int maxRoomPoints = 10;

    public static Vector3 sunPosition = GameObject.FindGameObjectWithTag("Sun").transform.position;

    public static float maxDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("MaxDistanceLightPoint").transform.position, sunPosition);
    public static float minDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("MinDistanceLightPoint").transform.position, sunPosition);


    private static int MaxPoints() => maxSunPoints + maxWaterPoints + maxRoomPoints;

    public static int CalcSunPoints(Vector3 plantPos, int desiredLightLevel)
    {
        //i sacrificed readability for optimization - bc otherwise this would kill performance
        switch(1f - (float)((maxDistance - Vector3.Distance(plantPos, sunPosition)) / (maxDistance - minDistance)))
        {
            case <= .33f:
                return 2 - Mathf.Abs(desiredLightLevel - 2);
            case <= .67f:
                return 2 - Mathf.Abs(desiredLightLevel - 1);
        }
        return 2 - desiredLightLevel;
    }

}
