using UnityEngine;
using System.Collections;

public class HoldItem : MonoBehaviour
{
    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    private float distanceFromCamera;
    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
            //rotateObject();
        }
        else
        {
            pickup();
        }
    }

    void rotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void carry(GameObject o)
    {
        Rigidbody R = o.GetComponent<Rigidbody>();
        if (R.isKinematic)
        {
            MeshCollider mesh = o.GetComponent<MeshCollider>();
            if (mesh != null)
            {
                mesh.enabled = false;
                R.isKinematic = false;
                o.GetComponent<BoxCollider>().enabled = true;
            }
        }
        Vector3 pos = Input.mousePosition;
        pos.z = distanceFromCamera;
        pos = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(pos);
        R.velocity = (pos - o.transform.position) * 10;
    }

    void pickup()
    {
        if (Input.GetMouseButton(1))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    distanceFromCamera = Vector3.Distance(carriedObject.transform.position, mainCamera.transform.position);
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetMouseButtonUp(1))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carriedObject.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        carrying = false;
        carriedObject = null;
    }
}
