using System;
using UnityEngine;

[RequireComponent(typeof(AgentMover))]
public class Guest : MonoBehaviour
{
    private AgentMover _mover;

    private void Awake()
    {
        _mover = GetComponent<AgentMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }
}