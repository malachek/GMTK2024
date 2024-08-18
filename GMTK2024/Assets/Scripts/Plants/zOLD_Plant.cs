using UnityEngine;

public class zOLD_Plant : MonoBehaviour
{
    //86400f
    // seconds to reach hours
    public float growthtime = 8f; // 24 hours in seconds
    private Vector3 initialScale;
    private Vector3 targetScale;
    private float currentTime = 0f;

    private int missedwaterPresses = 0; // to track the number of times T was not pressed
    private bool slowedGrowth = false; // to check if the growth has slowed down
    private bool[] growthStagesReached = new bool[4]; // to track if each growth stage has been reached

    public AudioClip audioClip1; // First audio clip
    public AudioClip audioClip2; // Second audio clip
    public AudioClip audioClip3; // Third audio clip
    public AudioClip audioClip4; // Fourth audio clip
    public AudioClip audioClip5; // Fifth audio clip
    public AudioClip audioClip6; // Sixth audio clip
    public AudioClip audioClip7; // Seventh audio clip
    public AudioClip audioClip8; // Eighth audio clip
    // Ninth audio clip

    private AudioSource audioSource1; // First audio source
    private AudioSource audioSource2; // Second audio source
    private AudioSource audioSource3; // Third audio source
    private AudioSource audioSource4; // Fourth audio source
    private AudioSource audioSource5; // Fifth audio source
    private AudioSource audioSource6; // Sixth audio source
    private AudioSource audioSource7; // Seventh audio source
    private AudioSource audioSource8; // Eighth audio source
    // Ninth audio source

    private Renderer plantRenderer; // To change the color of the plant

    void Start()
    {
        // To store the initial scale of the plant
        initialScale = transform.localScale;
        // To make the target grow by 10 units in the y-axis
        targetScale = new Vector3(initialScale.x, initialScale.y + 10f, initialScale.z);

        // Initializing the audio sources
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource4 = gameObject.AddComponent<AudioSource>();
        audioSource5 = gameObject.AddComponent<AudioSource>();
        audioSource6 = gameObject.AddComponent<AudioSource>();
        audioSource7 = gameObject.AddComponent<AudioSource>();
        audioSource8 = gameObject.AddComponent<AudioSource>();

        // Assigning the audio clips to the audio sources
        audioSource1.clip = audioClip1;
        audioSource2.clip = audioClip2;
        audioSource3.clip = audioClip3;
        audioSource4.clip = audioClip4;
        audioSource5.clip = audioClip5;
        audioSource6.clip = audioClip6;
        audioSource7.clip = audioClip7;
        audioSource8.clip = audioClip8;

        // to get the Renderer component to change the plant's color
        plantRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // this is to increase time by the time passed since the last frame
        currentTime += Time.deltaTime;

        // this is to calculate the percentage of time that has passed
        float timePercentage = currentTime / growthtime;

        // this is to implement the growth stages based on time percentage
        if (timePercentage >= 0.25f && !growthStagesReached[0])
        {
            // this is when it reaches 25% of growth when 25% of time has passed
            transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.25f);
            growthStagesReached[0] = true;

            // Change color to red at 25%
            plantRenderer.material.color = Color.red;
        }
        else if (timePercentage >= 0.5f && !growthStagesReached[1])
        {
            // this is when it reaches 50% of growth when 50% of time has passed
            transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.5f);
            growthStagesReached[1] = true;

            // this is to change color to green at 50%
            plantRenderer.material.color = Color.green;
        }
        else if (timePercentage >= 0.75f && !growthStagesReached[2])
        {
            // this is when it reaches 75% of growth when 75% of time has passed
            transform.localScale = Vector3.Lerp(initialScale, targetScale, 0.75f);
            growthStagesReached[2] = true;

            // Change color to black at 75%
            plantRenderer.material.color = Color.black;
        }
        else if (timePercentage >= 1f && !growthStagesReached[3])
        {
            //this is when it reaches 100% of growth when 100% of time has passed
            transform.localScale = Vector3.Lerp(initialScale, targetScale, 1f);
            growthStagesReached[3] = true;

            // this is to change color to cyan at 100%
            plantRenderer.material.color = Color.cyan;

            // for play the audio clips
            audioSource1.Play();
            audioSource2.Play();
            audioSource3.Play();
            audioSource4.Play();
            audioSource5.Play();
            audioSource6.Play();
            audioSource7.Play();
            audioSource8.Play();

            enabled = false; // stop this script when growth is complete
        }

        // this is to check if the player presses the "T" key
        if (Input.GetKeyDown(KeyCode.T))
        {
            missedwaterPresses = 0; // reset missed presses when "T" is pressed
            slowedGrowth = false; // reset growth speed
            growthtime = 8f; // reset growth time
        }

        // this is to check if 4 seconds have passed and "T" was not pressed
        if (currentTime % 4f < Time.deltaTime)
        {
            if (!Input.GetKeyDown(KeyCode.T))
            {
                missedwaterPresses++;
                if (missedwaterPresses >= 3)
                {
                    // Shrink the plant to size 1 if "T" was not pressed 3 times in time
                    targetScale = new Vector3(1f, 1f, 1f);
                }
                else if (!slowedGrowth)
                {
                    growthtime *= 2f; // slow down growth by doubling the time
                    slowedGrowth = true;
                }
            }
        }
    }
}


