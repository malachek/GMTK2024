using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ThePaper;
    [SerializeField] TextMeshProUGUI Text;

    bool IsTutorialActive;

    bool IsPlantingQueued = false;

    void Awake()
    {
        ThePaper.SetActive(false);
        TimeManager.OnNewDay += Welcome;
        Planting.OnPlantSeed += PlantingTutorial;
        TimeManager.OnNewDay += Growing;
        TimeManager.OnNewDay += Shrinking;
        TimeManager.OnNewDay += Shop;
        GrownState.OnReachedFullGrown += FullyGrown;
    }

    private void FixedUpdate()
    {
        if (IsTutorialActive)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ThePaper.SetActive(false);
                IsTutorialActive = false;
                
                if (IsPlantingQueued)
                {
                    StartCoroutine(WaitForPlantTutorial());
                }
            }
        }
    }

    void StartTutorial(string text)
    {
        Text.text = text;
        ThePaper.SetActive(true);
        IsTutorialActive=true;
    }

    void Welcome(int day)
    {
        TimeManager.OnNewDay -= Welcome;
        StartTutorial("Welcome to TerraBloom!\r\n\r\nIn this game your aim to to build your Terrarium\r\n\r\nUse the [W] and [S] to zoom in and out and [A] and [D] to rotate the Jar.\r\n\r\n");
        IsPlantingQueued = true;
    }

    IEnumerator WaitForPlantTutorial()
    {
        yield return new WaitForSeconds(3f);
        IsPlantingQueued = false;
        PlantingTutorial();
    }

    void PlantingTutorial()
    {
        Planting.OnPlantSeed -= PlantingTutorial;
        StartTutorial("Planting!\r\n\r\nClick on a seed pouch from the shelf\r\n\r\nPick up the seed that is dropped on the table\r\n\r\nHere's 3 ferns to test with!\r\n\r\n\r\n");
    }

    void Growing(int day)
    {
        if (day < 2) return;

        TimeManager.OnNewDay -= Growing;
        StartTutorial("Growing your plants!\r\n\r\nControl these 4 conditions.\r\n\r\nSunlight: Rotate the jar to adjust sunlight levels\r\n\r\nWater/moisture levels: Click on the spray bottle\r\n\r\nSoil Health: Soil health will decrease over time. Use fertilizer to bring it back up\r\n\r\nNeighbors: Plants have perfernces\r\n\r\n\r\n");
    }

    void Shrinking(int day)
    {
        if (day < 3) return;

        TimeManager.OnNewDay -= Shrinking;
        StartTutorial("Shrinking!\r\n\r\nPress the F key to skrink down into your Terrarium\r\n\r\nTalking to the insects will let you know the current state of your plant and what can be improved\r\n\r\n\r\n\r\n\r\n\r\n");
    }

    void Shop(int day)
    {
        if (day < 4) return;

        TimeManager.OnNewDay -= Shop;
        StartTutorial("Shop!\r\n\r\nThe ants have made a sneaky store inside the jar\r\n\r\nIn this store you can use the TerraBits (Money) you have to buy seeds and fertilizer for your Terrarium.\r\n");
    }

    void FullyGrown()
    {
        GrownState.OnReachedFullGrown -= FullyGrown;
        StartTutorial("You've managed fully grow your first plant. Great job!\r\n\r\nThe plant will now generate some TerraBit (money) everyturn you can spend in the Antmazon. (If you haven't found that yet, look for a hole in the jar)\r\n\r\nThe money you gets depends on how well you take care of it, so do your best\r\n\r\n\r\n\r\n");
    }

    void GameEnd()
    {
        StartTutorial("The End!\r\n\r\nThank you for playing our game! This is all we have for this game jam. We hope you enjoyed your time playing if you managed to get this far and thank you again for taking the time to play it!");
    }
}
