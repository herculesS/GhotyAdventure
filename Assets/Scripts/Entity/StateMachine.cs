
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State _state;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public Animator Animator { get { return _animator; } }

    public Rigidbody2D Rigidbody { get { return _rigidbody; } }

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    public void SetState(State state)
    {
        _state.End();
        _state = state;
        _state.Start();
    }

    protected virtual void Update()
    {
        _state.Update();
    }
}
