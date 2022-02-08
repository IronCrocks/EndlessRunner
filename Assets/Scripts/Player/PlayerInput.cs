using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        //_verticalInput = Input.GetAxis("Vertical");

        //if (_verticalInput > 0)
        //{
        //    _playerMover.TryMoveUp();
        //}
        //if (_verticalInput < 0)
        //{
        //    _playerMover.TryMoveDown();
        //}

        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerMover.TryMoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerMover.TryMoveDown();
        }
    }
}