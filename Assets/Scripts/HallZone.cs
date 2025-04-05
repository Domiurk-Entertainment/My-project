using Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HallZone : Zone
{
    // [SerializeField] private List<Guest> _guests;
    [SerializeField] private List<Spawner> _guestSpawners = new();
    [SerializeField] private List<Table> _tables = new();
    [SerializeField] private Vector2 _delayRange = new(5, 15);

    // private PoolBase<Guest> _pool;
    // private Timer _timer;

    private void Awake()
    {
        foreach(Spawner guestSpawner in _guestSpawners){
            guestSpawner.Spawned += GuestOnSpawned;
            continue;

            void GuestOnSpawned(GameObject gameObj)
            {
                Guest guest = gameObj.GetComponent<Guest>();
                Table table = _tables.First(t => t.CanSit());

                guest.Mover.MoveTo(table.transform.position);
                guest.GoOut += GuestOnGoOut;
                return;

                void GuestOnGoOut()
                {
                    guest.GoOut -= GuestOnGoOut;
                    guestSpawner.ForceReturn(guest.gameObject);
                }
            }
        }

        return;
        // _pool = new PoolBase<Guest>(PreloadFunc, GetAction, ReturnAction, MaxCounts);
        // _timer = new Timer(this);
        // _timer.Stopped += TimerOnStopped;

        // _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
        return;

        /*
        void TimerOnStopped()
        {
            if(_pool.Active.Count < MaxCounts)
                _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
            _pool.Get();
        }
    */
    }

    /*
    private void ReturnAction(Guest obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void GetAction(Guest obj)
    {
        obj.gameObject.SetActive(true);
        // obj.transform.position = _workerSpawnPoints[Random.Range(0, _workerSpawnPoints.Count)].position;
    }

    private Guest PreloadFunc()
        => Instantiate(_guests[Random.Range(0, _guests.Count)]);
*/
}