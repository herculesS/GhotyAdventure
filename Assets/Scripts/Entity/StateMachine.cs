
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State _state;
    protected State _previousState;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public Animator Animator { get { return _animator; } }
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Vector2 Velocity { get => _rigidbody.velocity; set => _rigidbody.velocity = value; }
    protected Vector2 _resumeVelocity = Vector2.zero;
    public Vector3 Position { get => transform.position; set => transform.position = value; }

    public bool IsPaused { get => _paused; }

    bool _paused = true;

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
        _resumeVelocity = Velocity;
        Velocity = Vector2.zero;
    }

    protected void resume()
    {
        _paused = false;
        Velocity = _resumeVelocity;
    }

    public float getCurrentAnimationDuration(int layer)
    {
        return Animator.GetCurrentAnimatorStateInfo(layer).length;
    }

    public void GoToPosition(Vector3 position)
    {
        SetState(new MoveToTargetPositionState(this, position));
    }


}
