using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerJump : MonoBehaviour
{

    private CharacterController _characterController;

    private Vector3 _playerVelocity;

    private bool _groundedPlayer;

    [SerializeField] private float _jumpHeigh = 5.0f;

    private bool _jumpPressed = false;

    private float _gravityValue = -9.81f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        MovementJump();
    }

    void MovementJump()
    {
        _groundedPlayer = _characterController.isGrounded;

        if (_groundedPlayer)
        {
            _playerVelocity.y = 0.0f;
        }

        if(_jumpPressed && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeigh * -1.0f * _gravityValue);
            _jumpPressed = false;
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    void OnJump ()
    { Debug.Log("jump pressed");

        if (_characterController.velocity.y == 0)
        { Debug.Log("Can Jump");
            _jumpPressed = true;        
        }
        else
        {
            Debug.Log("Cant jump - in the air");
        }
    
    }

}
