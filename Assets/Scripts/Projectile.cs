using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool set = false;
    public Vector3 firepos;
    public Vector3 firedir;
    public float speed;
    public float timeElapsed;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) Set(target.transform.position, target.transform.position, 2f);
        if (!set) return;
        timeElapsed += Time.deltaTime;
        transform.position = firepos + firedir * speed * timeElapsed;
        transform.position += Physics.gravity * (timeElapsed * timeElapsed) / 2.0f;
        if (transform.position.y < -1.0f) Destroy(gameObject);
    }

    public void Set(Vector3 firepos, Vector3 firedir, float speed)
    {
        this.firepos = firepos;
        this.firedir = firedir.normalized;
        this.speed = speed;
        transform.position = firepos;
        set = true;
    }
}
