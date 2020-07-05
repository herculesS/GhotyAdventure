
public abstract class State
{
    protected StateMachine _stateMachine;
    protected State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void End() { }

}
