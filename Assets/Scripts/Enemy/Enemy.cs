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

    public float damage;
    public float Damage { get { return damage;} set { damage = value; } }

    public float destoryTime;

    [SerializeField, Range(0,10)] public float attackRange;
    [SerializeField, Range(0, 10)] public float searchRange;

    private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; }  set { agent = value; } }

    public ParticleSystem bloodParticle;
    public Collider capsuleCollider;
    public Transform target;
    public Transform tempTarget;
    public LayerMask layerMask;
    public GameObject rootItem;

    public DropItem[] dropItem;
    public Transform dropItemPos;

    // Update is called once per frame
    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeState(State nextState)
    {
        stateMachine.ChangeState(nextState);
    }


    public virtual void TakeHit(float damage, RaycastHit hit)
    {
        hp -= damage;
        Instantiate(bloodParticle, hit.point, Quaternion.LookRotation(hit.normal)).transform.parent = this.transform;
        if (hp <= 0)
        {
            animator.SetTrigger("Dead");
            //Destroy(capsuleCollider);
            capsuleCollider.enabled = false;
            Dead();
        }
    }

    public void Dead()
    {
        int num = Random.Range(0, dropItem.Length);
        Debug.Log("Drop" + num);
        dropItem[num].Drop(dropItemPos);

        //Instantiate(rootItem, transform.position, transform.rotation);
        Destroy(gameObject, destoryTime);
    }


    public void TakeHit(float damage)
    {
        return;
    }
}
