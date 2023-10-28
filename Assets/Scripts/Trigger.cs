using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Tooltip("Позици¤ куда будет перемещен персонаж при входе в локацию")]
    public Vector2 EntryPoint;
    [Tooltip("Позици¤ где будет перемещенна камера")]
    public Vector2 CameraPoint;
    [Tooltip("Должна ли камера следить за персонажем (true - для маленьких локаций, false - для больших)")]
    public bool isCameraStatic;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*LocationManager manager = collision.gameObject.GetComponent < LocationManager > ();*/


    }
}
