using UnityEngine;

[CreateAssetMenu(menuName = "Location")]
public class LocationInfo : ScriptableObject
{
    [Tooltip("ѕозици€ куда будет перемещен персонаж при входе в локацию")]
    public Vector2 EntryPoint;
    [Tooltip("ѕозици€ где будет перемещенна камера")]
    public Vector2 CameraPoint;
    [Tooltip("ƒолжна ли камера следить за персонажем (true - дл€ маленьких локаций, false - дл€ больших)")]
    public bool isCameraStatic;
    [Tooltip("Ћокаци€ в которую будет перемещен персонаж при выходе")]
    public LocationInfo ExitLocation;
}
