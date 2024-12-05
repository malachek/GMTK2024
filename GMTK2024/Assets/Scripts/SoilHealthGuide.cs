using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTriggerAction.ActionSettings;

public class SoilHealthGuide : MonoBehaviour
{
    public delegate void OpenQuickTutorial();
    public static event OpenQuickTutorial OnOpenQuickTutorial;

    public void OnInteract(InteractGodMode interactGodMode)
    {
        Debug.Log("paper");
        OnOpenQuickTutorial?.Invoke();

    }

}
