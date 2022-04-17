using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FinishTrigger>(out _))
        {
            LevelManager.EndGameEvent.Invoke(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent<Plane>(out _))
        {
            LevelManager.EndGameEvent.Invoke(false);
        }
    }
}
