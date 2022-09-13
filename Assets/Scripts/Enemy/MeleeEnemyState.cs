using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeleeEnemyState
{
    public class BaseState : State<Enemy>
    {
        public override void Enter(Enemy Onwer)
        {
        }

        public override void Update(Enemy Onwer)
        {
        }

        public override void Exit(Enemy Onwer)
        {

        }
    }

    public class IdleState : BaseState
    {
        public override void Enter(Enemy Owner)
        {
            Owner.Animator.SetBool("Run", false);
            Owner.Animator.SetBool("Attack", false);
        }

        public override void Update(Enemy Owner)
        {
            //Owner.viewDetector.FindTarget();
            //GameObject target = Owner.viewDetector.target;
            //if (target != null)
            //    Owner.ChangeState(Enemy.State.Trace);
            if (Input.GetKeyDown(KeyCode.K)) Owner.ChangeState(Enemy.State.Trace);
        }

        public override void Exit(Enemy Owner)
        {

        }
    }

    public class TraceState : BaseState
    {
        public override void Enter(Enemy Owner)
        {
            Owner.Animator.SetBool("Run", true);
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(Owner.target.position);
        }

        public override void Update(Enemy Owner)
        {
            //Debug.Log(Owner.name + " : " + Owner.Agent.remainingDistance);
            //if (Input.GetKeyDown(KeyCode.K)) Owner.ChangeState(Enemy.State.Idle);
            if (Owner.Agent.remainingDistance < Owner.atkRange) Owner.ChangeState(Enemy.State.Attack);
            //if (Owner.Agent.destination == null) Owner.ChangeState(Enemy.State.Idle);
        }

        public override void Exit(Enemy Owner)
        {
            Owner.Agent.isStopped = true;
        }
    }

    public class AttackState : BaseState
    {
        public override void Enter(Enemy Owner)
        {
            Owner.Animator.SetBool("Attack", true);
        }

        public override void Update(Enemy Owner)
        {
            if (Owner.Agent.destination == null) Owner.ChangeState(Enemy.State.Trace);
        }

        public override void Exit(Enemy Owner)
        {
            Owner.Animator.SetBool("Attack", false);
        }
    }
}
