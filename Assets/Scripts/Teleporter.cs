﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportTarget.transform.position;
    }
}
