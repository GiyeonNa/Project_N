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
        audioSource = GetComponent<AudioSource>();

        target = GameObject.Find("Target").transform;
        tempTarget = GameObject.Find("Target").transform;

        stateMachine = new StateMachine<State, Enemy>(this);
        stateMachine.AddState(State.Idle, new MeleeEnemyState.IdleState());
        stateMachine.AddState(State.Trace, new MeleeEnemyState.TraceState());
        stateMachine.AddState(State.Attack, new MeleeEnemyState.AttackState());
        stateMachine.AddState(State.Hit, new MeleeEnemyState.HitState());
        stateMachine.AddState(State.Die, new MeleeEnemyState.DieState());

        stateMachine.ChangeState(State.Trace);
    }

    public override void TakeHit(float damage, RaycastHit hit)
    {
        Hp -= damage;
        Instantiate(bloodParticle, hit.point, Quaternion.LookRotation(hit.normal)).transform.parent = this.transform;
        Animator.SetTrigger("Hit");
        if (Hp <= 0) stateMachine.ChangeState(State.Die);
        //stateMachine.ChangeState(State.Hit);
    }

    public void OverLap()
    {
        Collider[] targets =  Physics.OverlapSphere(atkPos.position, atkarea, layerMask);
        for(int i=0; i<targets.Length; i++)
        {
            IDamagable target = targets[i].GetComponent<IDamagable>();
            target?.TakeHit(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(atkPos.position, atkarea);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, searchRange);
    }

}
