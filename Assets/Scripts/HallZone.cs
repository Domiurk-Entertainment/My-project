using System.Collections.Generic;
using UnityEngine;

public class HallZone : MonoBehaviour
{
    [field: SerializeField] public int MaxCounts { get; set; }

    [SerializeField] private List<Guest> _guests;
    [SerializeField] private List<Transform> _guestSpawnPoints;
    [SerializeField] private Vector2 _delayRange = new(5, 15);
    [SerializeField] private List<Transform> _workerSpawnPoints;

    private PoolBase<Guest> _pool;
    private Timer _timer;

    private void Awake()
    {
        _pool = new PoolBase<Guest>(PreloadFunc, GetAction, ReturnAction, MaxCounts);
        _timer = new Timer(this);
        _timer.Stopped += TimerOnStopped;

        _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
        return;

        void TimerOnStopped()
        {
            if(_pool.Active.Count < MaxCounts)
                _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
            _pool.Get();
        }
    }

    private void ReturnAction(Guest obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void GetAction(Guest obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = _workerSpawnPoints[Random.Range(0, _workerSpawnPoints.Count)].position;
    }

    private Guest PreloadFunc()
        => Instantiate(_guests[Random.Range(0, _guests.Count)]);
}