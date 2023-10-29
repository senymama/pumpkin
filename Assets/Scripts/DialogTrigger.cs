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

    private bool isActive = false;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();
        
        _CameraTrack = _Camera.GetComponent<CameraTracking>();

        _Dialog = _DialogBox.GetComponent<Dialogue>();

        keys.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
        if (collision.gameObject.tag == "Player")
        {
            isActive = true;
            keys.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(0);
        if (collision.gameObject.tag == "Player")
        {
            isActive = false;
            keys.SetActive(false);
        }
    }

    private void Update()
    {
        if (isActive && (Input.GetButtonDown("z") || Input.GetButtonDown("v")))
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
    }
}
