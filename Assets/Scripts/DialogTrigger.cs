using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _Camera;
    private Transform _CameraTransform;
    private CameraTracking _CameraTrack;

    [SerializeField]
    private GameObject _Player;
    private Transform _PlayerTransform;
    private MyCharacterController _PlayerController;

    [Tooltip("Позици¤ где будет перемещенна камера (не задавать если не нужно)")]
    public Transform CameraPoint;
    [SerializeField]
    private GameObject _Image;
    private SpriteRenderer _SpriteRenderer;

    public float teleportationTime = 0f;

    public List<string> text;

    [SerializeField]
    private GameObject _DialogBox;
    private Dialogue _Dialog;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();

        _CameraTransform = _Camera.transform;
        _CameraTrack = _Camera.GetComponent<CameraTracking>();

        _Dialog = _DialogBox.GetComponent<Dialogue>();

        _SpriteRenderer = _Image.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _PlayerController.isActivate = false;
            _PlayerController.StopMove();

            _CameraTrack.isTrackingActivate = false;
            if (CameraPoint != null)
            {
                _CameraTrack.CameraTeleportCoroutine(CameraPoint, _Image, teleportationTime/2, false);
            }

            _Dialog.teleportationTime = teleportationTime/2;
            _Dialog.lines = text;

            _Dialog.StartDialogue();
        }
    }

    
}
