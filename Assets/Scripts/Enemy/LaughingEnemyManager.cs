using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingEnemyManager : EnemyManager
{
    [SerializeField] Transform rightEye;
    [SerializeField] Transform leftEye;

    public Vector3 RightEye { get => rightEye.position; }
    public Vector3 LeftEye { get => leftEye.position; }

    protected override void Awake()
    {
        base.Awake();
        SetState(new EnemyCryingState(this));
    }


}
