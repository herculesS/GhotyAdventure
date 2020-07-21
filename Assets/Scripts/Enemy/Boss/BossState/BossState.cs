
public abstract class BossState : State
{
    protected EnemyManager _bossManager;
    private bool _isDone = false;
    public BossState(EnemyManager enemyManager) : base(enemyManager)
    {
        _bossManager = enemyManager;
    }

    public override void Start() {
        _isDone = false;
    }
    public bool IsDone { get => _isDone; set => _isDone = value; }
}
