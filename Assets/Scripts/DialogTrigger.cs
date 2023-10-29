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

    [SerializeField]
    private GameObject _DialogBox;
    private Dialogue _Dialog;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();
        
        _CameraTrack = _Camera.GetComponent<CameraTracking>();

        _Dialog = _DialogBox.GetComponent<Dialogue>();
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
                _CameraTrack.isTrackingPlayer = false;
                _CameraTrack.TargetPosition = CameraPoint;
            }

            _Dialog.lines = text;

            _Dialog.StartDialogue();
        }
    }

    
}
