using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player;
    private Transform _PlayerTransform;
    private MyCharacterController _PlayerController;

    private void Start()
    {
        _PlayerController = _Player.GetComponent<MyCharacterController>();
        _PlayerTransform = _Player.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _PlayerController.isActivate = false;
        }
    }
}
