using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Tooltip("������ ���� ����� ��������� �������� ��� ����� � �������")]
    public Vector2 EntryPoint;
    [Tooltip("������ ��� ����� ����������� ������")]
    public Vector2 CameraPoint;
    [Tooltip("������ �� ������ ������� �� ���������� (true - ��� ��������� �������, false - ��� �������)")]
    public bool isCameraStatic;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*LocationManager manager = collision.gameObject.GetComponent < LocationManager > ();*/


    }
}
