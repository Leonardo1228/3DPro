using UnityEngine;
using UnityEngine.Rendering;

public class LiftObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool CanLift = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZonaInteractuable")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
            AudioManager.Instance.Play2D("Detectar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZonaInteractuable")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }

}
