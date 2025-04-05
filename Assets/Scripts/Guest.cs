using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AgentMover))]
    public class Guest : MonoBehaviour
    {
        public Order Order;
        public event Action GoOut;
        [field: SerializeField] private float _eatingTime = 3;
        private Timer _timer;

        internal AgentMover Mover;

        private void Awake()
        {
            Mover = GetComponent<AgentMover>();
            _timer = new Timer(_eatingTime, this);
            _timer.Stopped += TimerOnStopped;
        }

        private void TimerOnStopped()
        {
            GoOut?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<Table>(out Table table) && Mover.Agent.isStopped){
                table.Sit();
            }
        }

        public void EndOrder()
        {
            _timer.Start();
        }
    }
}

public class Order
{
    public IReadOnlyList<Item> Items;
    
    private readonly List<Item> _items;

    public Order(params Item[] items)
    {
        _items = new List<Item>(items);
    }
}