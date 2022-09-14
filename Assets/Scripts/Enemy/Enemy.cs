using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IDamagable
{
    public enum State { Idle, Trace, Attack, Hit, Die}
    protected StateMachine<State, Enemy> stateMachine;

    public float hp;
    public float Hp { get { return hp;} set { hp = value; } }

    private float damage;
    public float Damage { get { return damage;} set { damage = value; } }

    [SerializeField, Range(0,10)] public float atkRange;
    [SerializeField, Range(0, 10)] public float searchRange;

    private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; }  set { agent = value; } }

    public ParticleSystem bloodParticle;
    public CapsuleCollider capsuleCollider;
    public float destoryTime;
    public Transform target;
    public Transform tempTarget;
    public LayerMask layerMask;

    // Update is called once per frame
    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(State nextState)
    {
        stateMachine.ChangeState(nextState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, atkRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, searchRange);
    }

    public virtual void TakeHit(float damage, RaycastHit hit)
    {
        hp -= damage;
        Instantiate(bloodParticle, hit.point, Quaternion.LookRotation(hit.normal)).transform.parent = this.transform;
        if (hp <= 0)
        {
            animator.SetTrigger("Dead");
            capsuleCollider.enabled = false;
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject, destoryTime);
    }
}
