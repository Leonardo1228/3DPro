using UnityEngine;

public class ActivateSound : MonoBehaviour
{
    public GameObject pos;
    public GameObject pos1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            //AudioManager.Instance.Play3D("Detectar",pos.transform.position);
            AudioManager.Instance.Play2D("Detectar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //AudioManager.Instance.Play3D("Detectar", pos.transform.position);
            AudioManager.Instance.Play2D("Detectar");
        }
    }
}
