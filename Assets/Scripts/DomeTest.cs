using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeTest : MonoBehaviour
{

    //[SerializeField] private Renderer renderer;
    [SerializeField] private Material material;
    private Vector2 vector = new Vector2(0.005f, 0);
    private void Awake()
    {
        //renderer = GetComponent<Renderer>();
        //material = renderer.material;
        //material = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += vector;
        if (material.mainTextureOffset.x >= 1)
        {
            material.mainTextureOffset = Vector2.zero;
        }
    }
}
