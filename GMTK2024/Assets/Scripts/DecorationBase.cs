using UnityEngine;

public class DecorationBase : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    private SO_Decoration decorData;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = decorData.Sprite;
    }

    protected virtual void Update()
    {
        transform.LookAt(Vector3.Scale(Camera.main.transform.position, new Vector3(1f, 0f, 1f)), Vector3.up);
    }
}
