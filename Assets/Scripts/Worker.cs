using System;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour, ICost
{
    public event Action StartedWork;
    // public event Action FinishedWork;
    
    public int Cost { get; }

    [SerializeField] private int _currentLevel = 1;
    // [SerializeField] private float _workSpeed = 1;
    [SerializeField] private List<float> _progressiveSpeed = new(){ 0.8f, 1, 1.1f, 1.2f, 1.3f };

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(this, _progressiveSpeed[_currentLevel - 1]);
        _timer.Started += StartedWork;
        _timer.Stopped += StartedWork;
    }

    public void StartWork(Product product)
    {
        _timer.Start(product.TimeCooking);
    }
}