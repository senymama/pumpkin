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
    private GameObject _Image;
    private SpriteRenderer _SpriteRenderer;

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

        _SpriteRenderer = _Image.GetComponent<SpriteRenderer>();
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
        StartCoroutine(Teleport());
        StartCoroutine(manifestation());
    }

    private IEnumerator Teleport()
    {
        _PlayerTransform.position = new Vector3(EntryPoint.position.x, EntryPoint.position.y, _PlayerTransform.position.z);
        _CameraTransform.position = new Vector3(EntryPoint.position.x, EntryPoint.position.y, _CameraTransform.position.z);
        if (isCameraDynamic)
        {
            _CameraTrack.isTrackingPlayer = true;
            _CameraTrack.TargetPosition = EntryPoint;
        }
        else
        {
            _CameraTrack.isTrackingPlayer = false;
            _CameraTrack.TargetPosition = CameraPoint;
        }
        yield return new WaitForSeconds(teleportationTime * 0.12f);
        _SpriteRenderer.enabled = false;
        _CameraTrack.isTrackingActivate = true;
        _PlayerController.isActivate = true;
    }

    private IEnumerator attenuation()
    {
        _SpriteRenderer.enabled = true;
        float time = 0;
        while (time < teleportationTime / 2)
        {
            Color c = _SpriteRenderer.color;
            _SpriteRenderer.color = new Color(c.r, c.g, c.b, (2 * time / teleportationTime));
            yield return null;
            time += Time.deltaTime;
        }
    }

    private IEnumerator manifestation()
    {
        float time = teleportationTime / 2;
        while (time > 0)
        {
            Color c = _SpriteRenderer.color;
            _SpriteRenderer.color = new Color(c.r, c.g, c.b, (2 * time / teleportationTime));
            yield return null;
            time -= Time.deltaTime;
        }
    }
}
