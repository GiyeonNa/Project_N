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

    public DropItem[] dropItem;
    public DropItems dropItems;
    public Transform dropItemPos;

    public AudioSource audioSource;
    public AudioClip deadSound;

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
            capsuleCollider.enabled = false;
            Dead();
        }
    }

    public void OnEnable()
    {
        stateMachine.ChangeState(State.Trace);
    }

    public void Dead()
    {
        int num = Random.Range(0, dropItem.Length);
        int tempnum = Random.Range(0, dropItems.items.Count);
        dropItem[num].Drop(dropItemPos);
        dropItems.items[tempnum].Drop(dropItemPos);
        audioSource.clip = deadSound;
        audioSource.Play();
        //중첩 소리
        //SoundManager.instance.Play(deadSound);

        //이름 뒤에 (Clone) 붙어서 에러가 난다.
        string[] tempStr = this.name.Split("(Clone)");
        ObjectPoolController.poolDic[tempStr[0]].ReturnObj(gameObject);
        
    }

    public IEnumerator DeadCo()
    {
        int num = Random.Range(0, dropItem.Length);
        dropItem[num].Drop(dropItemPos);
        audioSource.clip = deadSound;
        audioSource.Play();
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(destoryTime);
        //이름 뒤에 (Clone) 붙어서 에러가 난다.
        string[] tempStr = this.name.Split("(Clone)");
        ObjectPoolController.poolDic[tempStr[0]].ReturnObj(gameObject);
    }


    public void TakeHit(float damage)
    {
        return;
    }
}
