using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        var waitForThunder = Random.Range(2f, 10f);
        Invoke(nameof(RandomThunder), waitForThunder);
    }

    void RandomThunder()
    {
        _animator.SetTrigger("thunder");
        var waitForThunder = Random.Range(6f, 10f);
        Invoke(nameof(RandomThunder), waitForThunder);
    }

}
