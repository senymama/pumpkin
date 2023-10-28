using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
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
                    _Target = new Vector3(_player.position.x, _player.position.y, _z);
                }
                else
                {
                    _Target = new Vector3(TargetPosition.position.x, TargetPosition.position.y, _z);
                }
                transform.position = Vector3.Lerp(transform.position, _Target, Time.deltaTime * speed);
            }
            yield return null;
        }
    }
}
