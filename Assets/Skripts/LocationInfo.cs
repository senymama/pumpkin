using UnityEngine;

[CreateAssetMenu(menuName = "Location")]
public class LocationInfo : ScriptableObject
{
    [Tooltip("������� ���� ����� ��������� �������� ��� ����� � �������")]
    public Vector2 EntryPoint;
    [Tooltip("������� ��� ����� ����������� ������")]
    public Vector2 CameraPoint;
    [Tooltip("������ �� ������ ������� �� ���������� (false - ��� ��������� �������, true - ��� �������)")]
    public bool isCameraStatic;
    [Tooltip("������� � ������� ����� ��������� �������� ��� ������")]
    public LocationInfo ExitLocation;
}
