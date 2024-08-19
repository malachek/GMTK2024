using Cinemachine;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationSprite : MonoBehaviour
{
    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }


    protected virtual void Update()
    {
        transform.parent.transform.LookAt(PlayerSwitch.GetLookLocation());
    }

    public void ScaleTo(float percentSize)
    {
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, percentSize);
    }
}
