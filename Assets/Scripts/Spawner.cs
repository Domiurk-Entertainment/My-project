using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public event Action<GameObject> Spawned;  
    [field: SerializeField] public int MaxCounts { get; set; } = 1;

    [SerializeField] private GameObject _object;
    [SerializeField] private Vector2 _delayRange = new(5, 15);
    [SerializeField] private Vector3 _offset = Vector3.zero;

    private PoolBase<GameObject> _pool;
    private Timer _timer;

    private void Awake()
    {
        _pool = new PoolBase<GameObject>(PreloadFunc, GetAction, ReturnAction, MaxCounts);
        _timer = new Timer(this);
        _timer.Stopped += TimerOnStopped;

        _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
        return;

        void TimerOnStopped()
        {
            Spawn();
            if(_pool.Active.Count < MaxCounts)
                _timer.Start(Random.Range(_delayRange.x, _delayRange.y));
        }
    }

    public void Spawn()
        => Spawned?.Invoke(_pool.Get());

    public T[] GetsTo<T>() where T : MonoBehaviour
        => _pool.Active.Select(o => o.GetComponent<T>()).ToArray();

    public T GetFirstTo<T>()
        => _pool.Active[0].GetComponent<T>();

    public T GetLastTo<T>()
        => _pool.Active[^1].GetComponent<T>();

    private void ReturnAction(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void GetAction(GameObject obj)
    {
        obj.SetActive(true);
    }

    private GameObject PreloadFunc() => Instantiate(_object, transform.position + _offset, Quaternion.identity);

    public void ForceReturn(GameObject obj) 
        => _pool.Return(obj);
}