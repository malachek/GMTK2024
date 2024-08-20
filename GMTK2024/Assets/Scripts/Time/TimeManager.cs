using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int day { get; private set; }

    public delegate void NewDay(int day);
    public static event NewDay OnNewDay;

    // Start is called before the first frame update
    void Awake()
    {
        day = 0;
        StartNewDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNewDay();
        }
    }

    public void StartNewDay()
    {
        day++;
        Debug.Log($"Day {day} started!");
        OnNewDay?.Invoke(day);
    }
}
