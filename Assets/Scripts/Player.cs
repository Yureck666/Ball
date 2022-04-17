using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Init(LevelManager levelManager)
    {
        GetComponent<PlayerMoveController>().Init(levelManager);
    }
}
