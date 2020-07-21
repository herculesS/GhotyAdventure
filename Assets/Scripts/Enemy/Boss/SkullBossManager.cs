using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkullBossManager : EnemyManager
{
    AudioSource _audioSource;
    Vector3 _startPosition;
    List<BossState> stateList = new List<BossState>();
    bool started = false;
    bool _dead = false;
    public Vector3 StartPosition { get => _startPosition; private set => _startPosition = value; }

    public delegate void BossDeath();
    public event BossDeath OnSkullBossDeath;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        stateList.Add(new BossDashFowardState(this));
        stateList.Add(new SkullBossShootPlayer(this));
        stateList.Add(new SkullBossShootInCircle(this));
        stateList.Add(new SkullBossShootInCircle(this));
        resume();
    }
    void Start()
    {
        _health.Initialize(120f);
    }

    protected override void Update()
    {
        if (_dead) return;
        if (Health.CurrentHealth <= 0)
        {
            _dead = true;
            this.SetState(new SkullBossDeath(this));
        }

        base.Update();
        if (started) return;
        if (_state is MoveToTargetPositionState state && state.TargetReached)
        {
            _startPosition = transform.position;
            started = true;
            StartCoroutine(BossAI());
        }
    }

    IEnumerator BossAI()
    {
        while (started)
        {
            if (IsPaused) yield return null;
            if (_state is BossState state && !state.IsDone)
            {
                yield return null;
                continue;
            }

            _audioSource.Play();
            var index = Random.Range(0, stateList.Count);
            Debug.Log(stateList.Count.ToString());
            SetState(stateList[index]);
            var shootWaitTime = Random.Range(5f, 7f);
            yield return new WaitForSeconds(shootWaitTime);
        }


    }

    bool ValueInRange(float min, float max)
    {
        return Random.value > min && Random.value < max;
    }

    public Vector2 DirectionTowardsStartPosition()
    {
        return Position.DirectionTowards(_startPosition);
    }

    public float DistanceToStartPosition()
    {
        return Position.DistanceTo(_startPosition);
    }

    protected override void OnBecameInvisible()
    {

    }
    protected override void OnBecameVisible()
    {

    }

    public void OnDeath()
    {
        if (OnSkullBossDeath != null)
        {
            OnSkullBossDeath();
        }
    }

}
