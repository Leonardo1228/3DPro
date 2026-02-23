using UnityEngine;

public class CharControl : MonoBehaviour
{
    //Movimiento y Salto
    public CharacterController Controlador;
    public float Velocidad = 30f;
    public float Gravedad = -9.8f;
    public float SaltoFuerza = 3f;

    //Detectores de Distancia a Piso
    public Transform EnElPiso;
    public float DistanciaDelPiso;
    public LayerMask Piso;

    Vector3 VelocidadCaida;
    private bool EstanEnElPiso;

    //Camara
    public Camera mainCamera;
    private Vector3 camFoward;
    private Vector3 camRight;
    private Vector3 moveJugador;
    private Vector3 mover;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EstanEnElPiso = Physics.CheckSphere(EnElPiso.position, DistanciaDelPiso, Piso);
        if (EstanEnElPiso && VelocidadCaida.y < 0)
        {
            VelocidadCaida.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mover = new Vector3(x, 0, z);
        moveJugador = Vector3.ClampMagnitude(moveJugador, 1);
        moveJugador = mover.x * camRight + mover.z * camFoward;
        Controlador.Move(moveJugador * Velocidad * Time.deltaTime);
        Controlador.transform.LookAt(Controlador.transform.position + moveJugador);

        if (Input.GetButtonDown("Jump") && EstanEnElPiso)
        {
            VelocidadCaida.y = Mathf.Sqrt(SaltoFuerza * -2f * Gravedad);
        }

        VelocidadCaida.y += Gravedad * Time.deltaTime;

        Controlador.Move(VelocidadCaida * Time.deltaTime);

        DireccionCamara();

    }

    void DireccionCamara()
    {
        camFoward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camFoward.y = 0;
        camRight.y = 0;

        camFoward = camFoward.normalized;
        camRight = camRight.normalized;
    }
}
