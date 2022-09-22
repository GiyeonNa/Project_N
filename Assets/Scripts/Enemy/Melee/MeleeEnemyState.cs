using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeleeEnemyState
{
    public class BaseState : State<Enemy>
    {
        public override void Enter(Enemy Owner)
        {
        }

        public override void Update(Enemy Owner)
        {
        }

        public override void Exit(Enemy Owner)
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
            Owner.capsuleCollider.enabled = true;
            Owner.Agent.enabled = true;
            Owner.tempTarget = Owner.target;
            Owner.Agent.SetDestination(Owner.tempTarget.position);
            //Owner.Animator.SetLayerWeight(1, 0f);
            Owner.Animator.SetBool("Run", true);
            Owner.Agent.isStopped = false;
            
        }

        public override void Update(Enemy Owner)
        {
            Collider[] target = Physics.OverlapSphere(Owner.transform.position, Owner.searchRange,Owner.layerMask);
            if(target.Length != 0)
            {
                Owner.tempTarget = target[0].transform;
                Owner.Agent.SetDestination(Owner.tempTarget.position);
            }
            
            if (Owner.Agent.remainingDistance < Owner.Agent.stoppingDistance) 
                Owner.ChangeState(Enemy.State.Attack);
            
        }

        public override void Exit(Enemy Owner)
        {
            Owner.Agent.isStopped = true;
            Owner.Animator.SetBool("Run", false);
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
            
            //플레이어가 멀어졌을 경우도 계산해야함   
            if (Owner.tempTarget == null || Vector3.Distance(Owner.transform.position, Owner.tempTarget.position) > Owner.searchRange)
            {
                Owner.ChangeState(Enemy.State.Trace);
            }
            //Debug.Log(Vector3.Distance(Owner.transform.position ,Owner.tempTarget.position));

        }

        public override void Exit(Enemy Owner)
        {
            Owner.Animator.SetBool("Attack", false);
        }
    }

    public class HitState : BaseState
    {
        public override void Enter(Enemy Owner)
        {
            Owner.Animator.SetTrigger("Hit");
        }

        public override void Update(Enemy Owner)
        {
            
        }

        public override void Exit(Enemy Owner)
        {
            Owner.ChangeState(Enemy.State.Trace);
        }


    }

    public class DieState : BaseState
    {
        public override void Enter(Enemy Owner)
        {
            Owner.Animator.SetTrigger("Dead");
            Owner.capsuleCollider.enabled = false;
            Owner.Agent.enabled = false;
            Owner.Dead();
        }

        public override void Update(Enemy Owner)
        {
            
        }

        public override void Exit(Enemy Owner)
        {
            
        }
    }
}
