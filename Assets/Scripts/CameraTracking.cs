using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
    private GameObject _PlayerObj;
    private Transform _player;
    public Transform TargetPosition;
    public bool isTrackingPlayer = true;
    /*private Vector3 _Ofset;*/
    public float speed = 1.0f;
    public bool isTrackingActivate = true;
    [SerializeField]
    private Vector3 _Target;
    private float _z;

    private void Start()
    {
        _z = _Target.z;
        StartCoroutine(CameraTrackingCoroutine());
    }

    private IEnumerator CameraTrackingCoroutine()
    {
        while (true)
        {
            if (isTrackingActivate)
            {
                if (isTrackingPlayer)
                {
                    _Target = new Vector3(_PlayerObj.transform.position.x, _PlayerObj.transform.position.y, _z);
                }
                else
                {
                    _Target = new Vector3(TargetPosition.position.x, TargetPosition.position.y, _z);
                }
                transform.position = Vector3.Lerp(transform.position, _Target, Time.deltaTime * speed);
                transform.position = new Vector3(transform.position.x, transform.position.y, _z);
            }
            yield return null;
        }
    }

    public IEnumerator CameraTeleportCoroutine(Transform pos, GameObject _Image, float teleportationTime, bool isReturnControl)
    {
        SpriteRenderer _SpriteRenderer = _Image.GetComponent<SpriteRenderer>();

        MyCharacterController _PlayerController = _PlayerObj.GetComponent<MyCharacterController>();

        CameraTracking _CameraTrack = GetComponent<CameraTracking>();

        StartCoroutine(attenuation(_SpriteRenderer, teleportationTime));
        yield return new WaitForSeconds(teleportationTime / 2);
        StartCoroutine(CameraTeleport(pos, teleportationTime, transform, _CameraTrack, _SpriteRenderer));
        StartCoroutine(manifestation(_SpriteRenderer, teleportationTime, _PlayerController, isReturnControl));
    }

    private IEnumerator CameraTeleport(Transform pos, float teleportationTime, Transform _CameraTransform, CameraTracking _CameraTrack, SpriteRenderer _SpriteRenderer)
    {
        _CameraTransform.position = new Vector3(pos.position.x, pos.position.y, _CameraTransform.position.z);
        _CameraTrack.isTrackingPlayer = false;
        _CameraTrack.TargetPosition = pos;
        yield return new WaitForSeconds(teleportationTime * 0.12f);
        _SpriteRenderer.enabled = false;
        _CameraTrack.isTrackingActivate = true;
    }

    public IEnumerator attenuation(SpriteRenderer _SpriteRenderer, float teleportationTime)
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

    private IEnumerator manifestation(SpriteRenderer _SpriteRenderer, float teleportationTime, MyCharacterController _PlayerController, bool isReturnControl)
    {
        float time = teleportationTime / 2;
        while (time > 0)
        {
            Color c = _SpriteRenderer.color;
            _SpriteRenderer.color = new Color(c.r, c.g, c.b, (2 * time / teleportationTime));
            yield return null;
            time -= Time.deltaTime;
        }
        _PlayerController.isActivate = isReturnControl;
    }
}
