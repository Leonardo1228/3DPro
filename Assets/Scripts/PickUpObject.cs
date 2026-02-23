using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform ZonaInteractuable;

    void Update()
    {
        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<LiftObject>().CanLift == true && PickedObject == null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<LiftObject>().CanLift = false;
                PickedObject.transform.SetParent(ZonaInteractuable);
                PickedObject.transform.position = ZonaInteractuable.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }else if (PickedObject != null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    PickedObject = ObjectToPickUp;
                    PickedObject.GetComponent<LiftObject>().CanLift = true;
                    PickedObject.transform.SetParent(null);
                    PickedObject.GetComponent<Rigidbody>().useGravity = true;
                    PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                    PickedObject = null;
                }
            }
        }
    }
}
