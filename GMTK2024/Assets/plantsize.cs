using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 targetScale;
    private float currentTime = 0f;

    private int missedWaterPresses = 0; // to track the number of times T was not pressed
    private bool slowedGrowth = false; // to check if the growth has slowed down
    private bool[] growthStagesReached = new bool[4]; // to track if each growth stage has been reached

    public float growthtime = 8f; // Default growth time (this will be set according to the selected plant)

    public AudioClip audioClip1; // First audio clip
    public AudioClip audioClip2; // Second audio clip
    public AudioClip audioClip3; // Third audio clip
    public AudioClip audioClip4; // Fourth audio clip
    public AudioClip audioClip5; // Fifth audio clip
    public AudioClip audioClip6; // Sixth audio clip
    public AudioClip audioClip7; // Seventh audio clip
    public AudioClip audioClip8; // Eighth audio clip

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;
    private AudioSource audioSource4;
    private AudioSource audioSource5;
    private AudioSource audioSource6;
    private AudioSource audioSource7;
    private AudioSource audioSource8;

    private Renderer plantRenderer; // To change the color of the plant
    private bool plantSelected = false; // To track if a plant has been selected
    private bool showOptions = false; // To track if the options should be displayed
    private bool fullyGrown = false; // To check if the plant has fully grown

    void Start()
    {
        // Store the initial scale of the plant
        initialScale = transform.localScale;
        targetScale = new Vector3(initialScale.x, initialScale.y + 10f, initialScale.z);

        // Initialize the audio sources
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource4 = gameObject.AddComponent<AudioSource>();
        audioSource5 = gameObject.AddComponent<AudioSource>();
        audioSource6 = gameObject.AddComponent<AudioSource>();
        audioSource7 = gameObject.AddComponent<AudioSource>();
        audioSource8 = gameObject.AddComponent<AudioSource>();

        audioSource1.clip = audioClip1;
        audioSource2.clip = audioClip2;
        audioSource3.clip = audioClip3;
        audioSource4.clip = audioClip4;
        audioSource5.clip = audioClip5;
        audioSource6.clip = audioClip6;
        audioSource7.clip = audioClip7;
        audioSource8.clip = audioClip8;

        plantRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Show options when Z is pressed
        if (Input.GetKeyDown(KeyCode.Z) && !plantSelected)
        {
            showOptions = true;
        }

        // Handle plant selection
        if (showOptions && !plantSelected)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectPlant1();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectPlant2();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectPlant3();
            }
        }

        // Proceed with growth if a plant has been selected and not fully grown
        if (plantSelected && !fullyGrown)
        {
            currentTime += Time.deltaTime;
            float timePercentage = currentTime / growthtime;

            if (timePercentage >= 0.25f && !growthStagesReached[0])
            {
                // Reach 25% of growth when 25% of time has passed
                transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.25f);
                growthStagesReached[0] = true;
                ApplyColorChange(0.25f);
            }
            else if (timePercentage >= 0.5f && !growthStagesReached[1])
            {
                // Reach 50% of growth when 50% of time has passed
                transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.5f);
                growthStagesReached[1] = true;
                ApplyColorChange(0.5f);
            }
            else if (timePercentage >= 0.75f && !growthStagesReached[2])
            {
                // Reach 75% of growth when 75% of time has passed
                transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.75f);
                growthStagesReached[2] = true;
                ApplyColorChange(0.75f);
            }
            else if (timePercentage >= 1f && !growthStagesReached[3])
            {
                // Reach 100% of growth when 100% of time has passed
                transform.localScale = Vector3.Lerp(initialScale, targetScale, 1f);
                growthStagesReached[3] = true;
                ApplyColorChange(1f);

                // Play the audio clips when fully grown
                audioSource1.Play();
                audioSource2.Play();
                audioSource3.Play();
                audioSource4.Play();
                audioSource5.Play();
                audioSource6.Play();
                audioSource7.Play();
                audioSource8.Play();

                fullyGrown = true; // Mark the plant as fully grown
            }

            // Check if "T" key was pressed within the required interval
            if (currentTime % (growthtime * 0.2f) < Time.deltaTime && !fullyGrown)
            {
                if (!Input.GetKey(KeyCode.T))
                {
                    missedWaterPresses++;

                    if (missedWaterPresses < 3)
                    {
                        growthtime *= 2f; // Slow down growth by doubling the time after each miss
                    }
                    else if (missedWaterPresses >= 3)
                    {
                        // Shrink the plant to size 1 if "T" was not pressed 3 times in time
                        transform.localScale = Vector3.one;
                    }
                }
                else
                {
                    slowedGrowth = false; // Reset slowing growth if T is pressed
                }
            }
        }
    }

    void OnGUI()
    {
        // Display options if Z is pressed
        if (showOptions && !plantSelected)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "Press 1 for Plant 1 (10s growth)");
            GUI.Label(new Rect(10, 30, 300, 20), "Press 2 for Plant 2 (15s growth)");
            GUI.Label(new Rect(10, 50, 300, 20), "Press 3 for Plant 3 (20s growth)");
        }
    }

    void ApplyColorChange(float growthStage)
    {
        // Change color based on the selected plant and growth stage
        if (growthStage == 0.25f)
        {
            if (growthtime == 10f) plantRenderer.material.color = Color.red;
            else if (growthtime == 15f) plantRenderer.material.color = Color.cyan;
            else if (growthtime == 20f) plantRenderer.material.color = Color.yellow;
        }
        else if (growthStage == 0.5f)
        {
            if (growthtime == 10f) plantRenderer.material.color = Color.green;
            else if (growthtime == 15f) plantRenderer.material.color = Color.black;
            else if (growthtime == 20f) plantRenderer.material.color = Color.magenta;
        }
        else if (growthStage == 0.75f)
        {
            if (growthtime == 10f) plantRenderer.material.color = Color.black;
            else if (growthtime == 15f) plantRenderer.material.color = Color.green;
            else if (growthtime == 20f) plantRenderer.material.color = Color.blue;
        }
        else if (growthStage == 1f)
        {
            if (growthtime == 10f) plantRenderer.material.color = Color.cyan;
            else if (growthtime == 15f) plantRenderer.material.color = Color.red;
            else if (growthtime == 20f) plantRenderer.material.color = Color.white;
        }
    }

    void SelectPlant1()
    {
        growthtime = 10f;
        StartGrowth();
    }

    void SelectPlant2()
    {
        growthtime = 15f;
        StartGrowth();
    }

    void SelectPlant3()
    {
        growthtime = 20f;
        StartGrowth();
    }

    void StartGrowth()
    {
        plantSelected = true;
        showOptions = false; // Hide the options
    }
}
