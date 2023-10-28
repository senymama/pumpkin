using UnityEngine;

public class HideSpriteRendererOnStart : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.enabled = false;
    }
}