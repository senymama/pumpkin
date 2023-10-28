using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    [Tooltip("Позици¤ куда будет перемещен персонаж при входе в локацию")]
    public Transform EntryPoint;

    [Tooltip("Позици¤ где будет перемещенна камера")]
    public Transform CameraPoint;

    [Tooltip("Должна ли камера следить за персонажем (false - для маленьких локаций, true - для больших)")]
    public bool isCameraStatic;

    public float teleportationTime = 0f;

    [SerializeField]
    private Transform _CameraTransform;
    [SerializeField]
    private CameraTracking _Camera;

    [SerializeField]
    private Image _Image;

    [SerializeField]
    private Transform _PlayerTransform;
    [SerializeField]
    private MyCharacterController _PlayerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _PlayerController.isActivate = false;
            _Camera.isTrackingActivate = false;
            StartCoroutine(TeleportCoroutine());
        }

    }

    private IEnumerator TeleportCoroutine()
    {
        StartCoroutine(attenuation());
        yield return new WaitForSeconds(teleportationTime/2);
        _teleport();
        StartCoroutine(manifestation());
    }

    private void _teleport()
    {
        _PlayerTransform.position = EntryPoint.position;
        if (isCameraStatic)
        {
            _Camera.isTrackingActivate = true;
            _CameraTransform.position = EntryPoint.position;
        }
        else
        {
            _CameraTransform.position = CameraPoint.position;
        }
    }

    private IEnumerator attenuation()
    {
        yield return null;
    }

    private IEnumerator manifestation()
    {
        yield return null;
    }
}
