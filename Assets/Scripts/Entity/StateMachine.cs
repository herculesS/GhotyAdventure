
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State _state;
    protected State _previousState;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public Animator Animator { get { return _animator; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Vector3 Position => transform.position;

    public bool IsPaused { get => _paused; }

    bool _paused = false;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetState(State state)
    {
        _state.End();
        _previousState = _state;
        _state = state;
        _state.Start();
    }

    public void GoBack()
    {
        _state.End();
        _state = _previousState;
    }

    public void InitializeStateMachine(State state)
    {
        _state = state;
        _previousState = state;
        _state.Start();
    }

    protected virtual void Update()
    {
        if (_paused) return;
        _state.Update();
    }

    protected void pause()
    {
        _paused = true;
    }

    protected void resume()
    {
        _paused = false;
    }

    public float getCurrentAnimationDuration(int layer)
    {
        return Animator.GetCurrentAnimatorStateInfo(layer).length;
    }

}
