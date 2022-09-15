using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemy : Enemy
{
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        target = GameObject.Find("Target").transform;
        tempTarget = GameObject.Find("Target").transform;

        stateMachine = new StateMachine<State, Enemy>(this);
        stateMachine.AddState(State.Idle, new RangeEnemyState.IdleState());
        stateMachine.AddState(State.Trace, new RangeEnemyState.TraceState());
        stateMachine.AddState(State.Attack, new RangeEnemyState.AttackState());
        stateMachine.AddState(State.Hit, new RangeEnemyState.HitState());
        stateMachine.AddState(State.Die, new RangeEnemyState.DieState());

        stateMachine.ChangeState(State.Idle);
    }

    public override void TakeHit(float damage, RaycastHit hit)
    {
        Hp -= damage;
        Instantiate(bloodParticle, hit.point, Quaternion.LookRotation(hit.normal)).transform.parent = this.transform;
        Animator.SetTrigger("Hit");
        if (Hp <= 0) stateMachine.ChangeState(State.Die);
        //stateMachine.ChangeState(State.Hit);
    }

    public void RangeAttack()
    {
        Debug.Log("Attack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, searchRange);
    }
}
