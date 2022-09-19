using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject prefab;
    public GameObject preViewPrefab;
}

public class CraftManual : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;
    private bool isPreViewAct = false;
    [SerializeField] private GameObject baseUI;

    [SerializeField] private Craft[] craft;
    private GameObject preview;
    private GameObject prefab;

    [SerializeField] private Transform player;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range;
    [SerializeField] private float rotateSpeed;
    
    public void SlotClick(int slotNumber)
    {
        preview = Instantiate(craft[slotNumber].preViewPrefab, player.position + player.forward, Quaternion.identity);
        prefab = craft[slotNumber].prefab;
        isPreViewAct = true;
        baseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Tab) && !isPreViewAct)
        {
            Debug.Log("Show");
            Window();
        }

        if (isPreViewAct) PreviewPosUpdate();

        if (Input.GetButtonDown("Fire1")) Build();

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.Q)) Rotate(KeyCode.Q);
            if (Input.GetKey(KeyCode.E)) Rotate(KeyCode.E);
        }

        //if (Input.GetKeyDown(KeyCode.Escape)) Cancel();

        if (Input.GetButtonDown("Fire2")) Cancel();

    }

    private void Rotate(KeyCode key)
    {
        if (isPreViewAct)
        {
            switch (key){
                case KeyCode.Q:
                    preview.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                    break;
                case KeyCode.E:
                    preview.transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
                    break;
            }
            
            //preview.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime);

        }
        
    }

    private void Build()
    {
        if (isPreViewAct && preview.GetComponent<PreViewObject>().isBuildable())
        {
            Instantiate(prefab, hit.point, preview.transform.rotation);
            Destroy(preview);
            isActivated = false;
            isPreViewAct = false;
            preview = null;
            prefab = null;
        }
    }

    private void PreviewPosUpdate()
    {
        if(Physics.Raycast(player.position, player.forward, out hit, range, layerMask))
        {
            if(hit.transform != null)
            {
                Vector3 location = hit.point;
                preview.transform.position = location;
            }
        }
    }

    private void Cancel()
    {
        if(isPreViewAct) Destroy(preview);
        isActivated = false;
        isPreViewAct = false;
        preview = null;
        prefab = null;
        baseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Window()
    {
        if (!isActivated) OpenWindow();
        else CloseWindow();
    }

    private void OpenWindow()
    {
        isActivated = true;
        baseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void CloseWindow()
    {
        isActivated = false;
        baseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
