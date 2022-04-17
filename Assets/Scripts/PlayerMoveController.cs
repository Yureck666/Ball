using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private LevelManager _levelManager;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private bool _gameIsPlaying;

    public void Init(LevelManager levelManager)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _direction = Vector3.zero;
        _gameIsPlaying = false;
        _levelManager = levelManager;
    }

    void Update()
    {
        CheckKey(KeyCode.A, Vector3.left);
        CheckKey(KeyCode.W, Vector3.forward);
        CheckKey(KeyCode.S, Vector3.back);
        CheckKey(KeyCode.D, Vector3.right);
        _rigidbody.AddForce(_direction * Time.deltaTime * speed);
    }

    private void CheckKey(KeyCode keyCode, Vector3 direction)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (!_gameIsPlaying)
            {
                _levelManager.StartGame();
                _gameIsPlaying = true;
            }
            _direction += direction;
        }
        if (Input.GetKeyUp(keyCode))
        {
            _direction -= direction;
        }
    }
}
