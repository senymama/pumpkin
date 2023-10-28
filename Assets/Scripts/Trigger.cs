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
    public bool isCameraDynamic;

    public float teleportationTime = 0f;

    [SerializeField]
    private GameObject _Camera;
    private Transform _CameraTransform;
    private CameraTracking _CameraTrack;

    [SerializeField]
    private Image _Image;

    [SerializeField]
    private GameObject _Player;
    private Transform _PlayerTransform;
    private MyCharacterController _PlayerController;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();
        _PlayerTransform = _Player.transform;

        _CameraTransform = _Camera.transform;
        _CameraTrack = _Camera.GetComponent<CameraTracking>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _PlayerController.isActivate = false;
            _PlayerController.StopMove();
            _CameraTrack.isTrackingActivate = false;
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
        _PlayerTransform.position = new Vector3(EntryPoint.position.x, EntryPoint.position.y, _PlayerTransform.position.z);
        if (isCameraDynamic)
        {
            _CameraTrack.isTrackingPlayer = true;
            _CameraTransform.position = EntryPoint.position;
            _CameraTrack.TargetPosition = EntryPoint;
        }
        else
        {
            _CameraTransform.position = EntryPoint.position;
            _CameraTrack.isTrackingPlayer = false;
            _CameraTrack.TargetPosition = CameraPoint;
        }
    }

    private IEnumerator attenuation()
    {
        _Image.enabled = true;
        float time = 0;
        while (time < teleportationTime / 2)
        {
            Color c = _Image.color;
            _Image.color = new Color(c.r, c.g, c.b, (2 * time / teleportationTime));
            yield return null;
            time += Time.deltaTime;
        }
    }

    private IEnumerator manifestation()
    {
        float time = teleportationTime / 2;
        while (time > 0)
        {
            Color c = _Image.color;
            _Image.color = new Color(c.r, c.g, c.b, (2 * time / teleportationTime));
            yield return null;
            time -= Time.deltaTime;
        }
        _Image.enabled = false;
        _CameraTrack.isTrackingActivate = true;
        yield return new WaitForFixedUpdate();
        _PlayerController.isActivate = true;
    }
}
