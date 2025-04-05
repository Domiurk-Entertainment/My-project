using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action Started;
    public event Action Stopped;
    public event Action Paused;
    public event Action Resumed;
    public event Action<float> Updated;

    private float _remainingTime;
    private float _time;
    private float _step;
    private readonly MonoBehaviour _mono;
    private readonly IEnumerator _coroutine;

    public Timer(MonoBehaviour mono, float step = 1) : this(0, mono, step) { }

    public Timer(float time, MonoBehaviour mono, float step = 1)
    {
        _remainingTime = time;
        _time = time;
        _step = step;
        _mono = mono;
        _coroutine = Play();
    }

    public void Start()
    {
        Started?.Invoke();
        _mono.StartCoroutine(_coroutine);
    }

    public void Start(float customTime, float step = 1)
    {
        Started?.Invoke();
        _time = customTime;
        _step = step;
        _remainingTime = _time;
        _mono.StartCoroutine(_coroutine);
    }

    public void Stop()
    {
        Stopped?.Invoke();
        if(_coroutine != null)
            _mono.StopCoroutine(_coroutine);
        _remainingTime = _time;
    }

    public void Pause()
    {
        Paused?.Invoke();
        _mono.StopCoroutine(_coroutine);
    }

    public void Resume()
    {
        Resumed?.Invoke();
        _mono.StartCoroutine(_coroutine);
    }

    private IEnumerator Play()
    {
        _remainingTime -= _step;
        Updated?.Invoke(_remainingTime);

        while(_remainingTime > 0){
            yield return new WaitForSeconds(1);
            _remainingTime -= _step;
            Updated?.Invoke(_remainingTime);
        }

        Stop();
    }
}