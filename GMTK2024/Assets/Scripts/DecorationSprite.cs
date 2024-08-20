using Cinemachine;
using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationSprite : MonoBehaviour
{
    Transform GodCameraTransform;
    Transform SmallCameraTransform;

    Color c;

    bool IsGodMode = true;

    private void Awake()
    {
        PlayerSwitch.OnSwitchToGod += SwitchToGod;
        PlayerSwitch.OnSwitchToSmall += SwitchToSmall;
    }

    private void Start()
    {
        GodCameraTransform = PlayerSwitch.GetGodCameraLocation();
        SmallCameraTransform = PlayerSwitch.GetSmallCameraLocation();
    }

    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        c = GetComponent<SpriteRenderer>().color;
    }

    public void BeHappy()
    {
        StartCoroutine(ColorMeHappy());
    }

    IEnumerator ColorMeHappy()
    {
        if (c != null)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            yield return new WaitForSeconds(.5f);
            GetComponent<SpriteRenderer>().color = c;
        }
        yield return null;
    }

    void SwitchToGod()
    {
        IsGodMode = true;
    }
    void SwitchToSmall()
    {
        IsGodMode = false;
    }

    protected virtual void Update()
    {
        //transform.parent.transform.LookAt(PlayerSwitch.GetLookLocation());
        transform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(IsGodMode? GodCameraTransform.position - transform.position : SmallCameraTransform.position - transform.position).eulerAngles.y, 0);
    }

    public void ScaleTo(float percentSize)
    {
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, percentSize);
    }
}
