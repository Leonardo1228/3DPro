using UnityEngine;

public class PushRB : MonoBehaviour
{
    public float Empuje = 5.0f;
    private float MasaCollecion;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody objeto = hit.collider.attachedRigidbody;
        if(objeto == null || objeto.isKinematic)
        {
            return;
        }
        if(hit.moveDirection.y < -0 / 0.3)
        {
            return;
        }
        MasaCollecion = objeto.mass;
        Vector3 empujeDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        objeto.linearVelocity = empujeDir * Empuje/MasaCollecion;
    }
}
