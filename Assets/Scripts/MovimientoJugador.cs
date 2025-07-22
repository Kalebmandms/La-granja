using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    Rigidbody2D rb;
    public Vector2 entrada;
    private Animator animator;
    public GameObject trigoPreFab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = entrada * velocidad; // Corrección aquí
    }

    public void Moverse(InputAction.CallbackContext contexto)
    {
        Vector2 valorEntrada = contexto.ReadValue<Vector2>();

        animator.SetBool("estaCaminando", valorEntrada != Vector2.zero);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }

        animator.SetFloat("entradaX", entrada.x);
        animator.SetFloat("entradaY", entrada.y);
    }

    public void SembrarTrigo(InputAction.CallbackContext contexto)
    {
        if (contexto.performed)
        {
            Instantiate(trigoPreFab, transform.position, Quaternion.identity); // Corrección aquí
        }
    }
}
