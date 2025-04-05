using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolBase<TObject>
{
    public IReadOnlyList<TObject> Active => _active;
    private readonly Func<TObject> _preloadFunc;
    private readonly Action<TObject> _getAction;
    private readonly Action<TObject> _returnAction;
    private readonly Queue<TObject> _pool = new Queue<TObject>();
    private readonly List<TObject> _active = new List<TObject>();

    public PoolBase(Func<TObject> preloadFunc,
                    Action<TObject> getAction,
                    Action<TObject> returnAction,
                    int preloadCount)
    {
        _preloadFunc = preloadFunc;
        _getAction = getAction;
        _returnAction = returnAction;

        if(preloadFunc == null){
            Debug.Log("Preload Function is Null");
            return;
        }

        for(int i = 0; i < preloadCount; i++)
            Return(_preloadFunc());
    }

    public TObject Get()
    {
        TObject item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
        _active.Add(item);
        _getAction?.Invoke(item);
        return item;
    }

    public void Return(TObject item)
    {
        _pool.Enqueue(item);
        _active.Remove(item);
        _returnAction?.Invoke(item);
    }
}