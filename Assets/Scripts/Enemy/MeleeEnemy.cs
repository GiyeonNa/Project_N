using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy
{
    public Transform atkPos;
    public float atkarea;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        target = GameObject.Find("Target").transform;
        tempTarget = GameObject.Find("Target").transform;

        stateMachine = new StateMachine<State, Enemy>(this);
        stateMachine.AddState(State.Idle, new MeleeEnemyState.IdleState());
        stateMachine.AddState(State.Trace, new MeleeEnemyState.TraceState());
        stateMachine.AddState(State.Attack, new MeleeEnemyState.AttackState());
        stateMachine.AddState(State.Hit, new MeleeEnemyState.HitState());
        stateMachine.AddState(State.Die, new MeleeEnemyState.DieState());

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

    public void AttackAreaOn()
    {
        attackArea.enabled = true;
    }

    public void AttackAreaOff()
    {
        attackArea.enabled = false;
    }

    public void OverLap()
    {
        RaycastHit hit;
        Collider[] targets =  Physics.OverlapSphere(atkPos.position, atkarea, layerMask);
        if (targets.Length > 0)
        {
            IDamagable asdf = targets[0].GetComponent<IDamagable>();
            asdf?.TakeHit();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(atkPos.position, atkarea);
    }


}
