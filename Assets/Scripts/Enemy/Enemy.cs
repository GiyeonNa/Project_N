using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public enum State { Idle, Trace, Attack, Hit, Die}
    protected StateMachine<State, Enemy> stateMachine;

    private float hp;
    public float Hp { get { return hp;} set { hp = value; } }

    private float damage;
    public float Damage { get { return damage;} set { damage = value; } }

    [SerializeField, Range(0,10)] public float atkRange;

    private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; }  set { agent = value; } }

    public Transform target;

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
    }




}
