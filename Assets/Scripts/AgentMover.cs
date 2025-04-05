using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMover : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }
    
    [SerializeField] private float _range = 5;

    private static readonly int vert = Animator.StringToHash("Vert");
    private static readonly int hor = Animator.StringToHash("Hor");

    private Animator _animator;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Agent.velocity.magnitude == 0)
            return;
        _animator.SetFloat(hor, Agent.velocity.x);
        _animator.SetFloat(vert, Agent.velocity.y);
    }

    
    public void MoveTo(Vector3 position)
    {
        float distance = Vector3.Distance(Agent.transform.position, position);
        if(distance < _range)
            Agent.isStopped = true;
        Agent.destination = position;
    }
}