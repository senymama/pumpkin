using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _Camera;
    private CameraTracking _CameraTrack;

    [SerializeField]
    private GameObject _Player;
    private MyCharacterController _PlayerController;

    [Tooltip("Позици¤ где будет перемещенна камера (не задавать если не нужно)")]
    public Transform CameraPoint;

    public List<string> text;

    public GameObject keys;

    [SerializeField]
    private GameObject _DialogBox;
    private Dialogue _Dialog;

    public bool isAutoStart;

    private bool isActive = false;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();

        _CameraTrack = _Camera.GetComponent<CameraTracking>();

        _Dialog = _DialogBox.GetComponent<Dialogue>();

        keys.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isautoStart)
            {
                _PlayerController.isActivate = false;
                _PlayerController.StopMove();

                _CameraTrack.isTrackingActivate = false;
                if (CameraPoint != null)
                {
                    _CameraTrack.isTrackingPlayer = false;
                    _CameraTrack.TargetPosition = CameraPoint;
                }

                _Dialog.lines = text;

                _Dialog.StartDialogue();
            }
            else
            {
                isActive = true;
                keys.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = false;
            keys.SetActive(false);
        }
    }

    private void Update()
    {
        if (isActive && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.V)))
        {
            _PlayerController.isActivate = false;
            _PlayerController.StopMove();

            if (CameraPoint != null)
            {
                _CameraTrack.isTrackingPlayer = false;
                _CameraTrack.TargetPosition = CameraPoint;
            }

            _Dialog.lines = text;

            _Dialog.StartDialogue();
        }
    }
}
