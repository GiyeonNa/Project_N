using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy
{

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine = new StateMachine<State, Enemy>(this);
        stateMachine.AddState(State.Idle, new MeleeEnemyState.IdleState());
        stateMachine.AddState(State.Trace, new MeleeEnemyState.TraceState());
        stateMachine.AddState(State.Attack, new MeleeEnemyState.AttackState());
        ////stateMachine.AddState(State.Hit, new RangeWolfStates.HitState());
        ////stateMachine.AddState(State.Die, new RangeWolfStates.DieState());

        stateMachine.ChangeState(State.Idle);
    }


}
