using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    public BaseGun curGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) curGun.Shot();
        if (Input.GetKeyDown(KeyCode.R)) curGun.Reload();
    }
}
