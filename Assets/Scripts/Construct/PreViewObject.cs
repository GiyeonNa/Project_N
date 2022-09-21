using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreViewObject : MonoBehaviour
{

    private List<Collider> colliders = new List<Collider>();

    [SerializeField] private int groundLayer;
    private const int ignoreLayer = 2;

    [SerializeField] private Material green;
    [SerializeField] private Material red;



    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (colliders.Count > 0) SetColor(red); //red;
        else SetColor(green);//green
    }

    private void SetColor(Material mat)
    {
        //자식 no
        if (transform.childCount == 0)
        {
            var newMaterial = new Material[GetComponent<Renderer>().materials.Length];
            for (int i = 0; i < newMaterial.Length; i++)
            {
                newMaterial[i] = mat;
            }
            this.GetComponent<Renderer>().materials = newMaterial;
        }


        //자식
        foreach(Transform child in transform)
        {
            //Debug.Log("Have Child");
            
            var newMaterial = new Material[child.GetComponent<Renderer>().materials.Length];
            for(int i=0; i<newMaterial.Length; i++)
            {
                newMaterial[i] = mat;
            }
            child.GetComponent<Renderer>().materials = newMaterial;
        }

    }

    public bool isBuildable()
    {
        return colliders.Count == 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != groundLayer && other.gameObject.layer != ignoreLayer)
            colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != groundLayer && other.gameObject.layer != ignoreLayer)
            colliders.Remove(other);
    }
}
