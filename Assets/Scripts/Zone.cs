using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Spawner _workerSpawner;

    private void Awake()
    {
        _workerSpawner.Spawned += WorkerOnSpawned;
    }

    private void WorkerOnSpawned(GameObject obj)
    {
        
    }
}