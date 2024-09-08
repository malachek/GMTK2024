using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int day { get; private set; }

    public delegate void NewDay(int day);
    public static event NewDay OnNewDay;

    private int timesPlantsWateredToday = 0;

    private float newDayWaitTimer;
    private float maxTimer = 8f;

    [SerializeField] SpriteRenderer sunSR;
    [SerializeField] Color clickedSunColor;

    // Start is called before the first frame update
    void Awake()
    {
        day = 0;
        StartNewDay();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNewDay();
        }
    }*/

    private void LateUpdate()
    {
        if (newDayWaitTimer > 0f)
        {
            newDayWaitTimer -= Time.deltaTime;
        }
    }

    public void StartNewDay()
    {
        if (newDayWaitTimer > 0f)
        {
            Debug.Log($"Wait {newDayWaitTimer} seconds");
            return;
        }
        newDayWaitTimer = maxTimer;
        StartCoroutine(SunClickColor());
        day++;
        timesPlantsWateredToday = 0;
        Debug.Log($"Day {day} started!");
        OnNewDay?.Invoke(day);
    }

    private IEnumerator SunClickColor()
    {
        Color sunColor = sunSR.color;
        sunSR.color = clickedSunColor;
        yield return new WaitForSeconds(.5f);
        sunSR.color = sunColor;

    }

    void CanStartNewDay()
    {

    }

    public void WateredPlant()
    {
        timesPlantsWateredToday++;
    }
}
