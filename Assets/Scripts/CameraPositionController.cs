using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    private Transform _player;
    private Vector3 _dealtaPos;

    public void SetPlayer(Transform player)
    {
        _player = player;
        _dealtaPos = transform.position - _player.position;
    }

    private void Update()
    {
        if (_player != null)
        {
            transform.position = _player.position + _dealtaPos;
        }
    }
}
