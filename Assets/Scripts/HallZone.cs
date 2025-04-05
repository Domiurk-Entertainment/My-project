using Game;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HallZone : Zone
{
    [SerializeField] private List<Spawner> _guestSpawners = new();
    [SerializeField] private List<Table> _tables = new();
    [SerializeField] private Vector2 _delayRange = new(5, 15);

    private void Start()
    {
        foreach(Spawner guestSpawner in _guestSpawners){
            guestSpawner.Spawned += GuestOnSpawned;
            continue;

            void GuestOnSpawned(GameObject gameObj)
            {
                Guest guest = gameObj.GetComponent<Guest>();
                Table table = _tables.First(t=>t.Number == 4);
                // Table table = _tables.First(t => t.CanSit());
                print(table);
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

    }
}