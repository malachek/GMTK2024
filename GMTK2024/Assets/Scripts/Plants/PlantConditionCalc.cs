using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantConditionCalc
{
    public static int maxSunPoints = 2;
    public static int maxWaterPoints = 10;
    public static int maxRoomPoints = 10;

    public static Vector3 sunPosition = new Vector3(-125, 50, -125);

    public static float maxDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("MaxDistanceLightPoint").transform.position, sunPosition);
    public static float minDistance = Vector3.Distance(GameObject.FindGameObjectWithTag("MinDistanceLightPoint").transform.position, sunPosition);


    private static int MaxPoints() => maxSunPoints + maxWaterPoints + maxRoomPoints;

    public static int CalcSunPoints(Transform plantPos, int desiredLightLevel)
    {
        //i sacrificed readability for optimization - bc otherwise this would kill performance
        switch(1f - (float)((maxDistance - Vector3.Distance(plantPos.position, sunPosition)) / (maxDistance - minDistance)))
        {
            case <= .33f:
                return 2 - Mathf.Abs(desiredLightLevel - 2);
            case <= .67f:
                return 2 - Mathf.Abs(desiredLightLevel - 1);
        }
        return 2 - desiredLightLevel;
    }
}
