using UnityEngine;
using UnityEngine.Tilemaps;

public class HideTilemapRendererOnStart : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    void Start()
    {
        tilemap.color = Color.clear;
    }
}