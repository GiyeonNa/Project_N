using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    Queue<GameObject> objPool = new Queue<GameObject>();
    public GameObject part;
    Transform tempTransform;
    //
    private void OnEnable()
    {
        //활성화하면 코루틴하면서 n초뒤에 다시 자신을 큐에 넣는다.위치정보도 넣을 수 있다.
        //이것은 prefab에 들어간다.

    }

    void AddPoll(int size = 1)
    {
        for(int i=0; i<size; i++)
        {
            float x = Random.Range(-3f, 3f);
            //Vector3 tempVec = this.transform.transform + new Vector3(x, 0, 0);
            GameObject temp = Instantiate(part, new Vector3(this.transform.position.x + x, this.transform.position.y, this.transform.position.z), Quaternion.identity, this.transform);
            temp.SetActive(false);
            objPool.Enqueue(temp);
        }
    }

    void Dequeue()
    {
        if (objPool.Count <= 0) AddPoll(10);
        GameObject temp =  objPool.Dequeue();
        temp.SetActive(true);
    }
    
    void Dequeue(int value)
    {
        if (objPool.Count <= 0) AddPoll(10);
        for(int i=0; i<value; i++)
        {
            GameObject temp = objPool.Dequeue();
            temp.SetActive(true);
        }
    }

    IEnumerator DequeueCo(float cooldown)
    {
        if (objPool.Count <= 0) AddPoll(10);

        GameObject temp = objPool.Dequeue();
        temp.SetActive(true);

        yield return new WaitForSeconds(cooldown);
        StartCoroutine(DequeueCo(cooldown));
    }

    // Start is called before the first frame update
    void Start()
    {
        AddPoll(10);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K)) Dequeue(3);
        if (Input.GetKeyDown(KeyCode.K)) StartCoroutine(DequeueCo(1.5f));
    }
}
