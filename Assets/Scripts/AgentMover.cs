using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMover : MonoBehaviour
{
    [SerializeField] private float _range = 5;
    
    private static readonly int vert = Animator.StringToHash("Vert");
    private static readonly int hor = Animator.StringToHash("Hor");
    
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_agent.velocity.magnitude == 0)
            return;
        _animator.SetFloat(hor, _agent.velocity.x);
        _animator.SetFloat(vert, _agent.velocity.y);
    }

    
    public void MoveTo(Vector3 position)
    {
        float distance = Vector3.Distance(_agent.transform.position, position);
        if(distance < _range)
            _agent.isStopped = true;
        _agent.destination = position;
    }
}