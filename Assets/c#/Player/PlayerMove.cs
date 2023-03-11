using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // velocidad a la que se mueve el personaje.
    [SerializeField] private float speed = 5;

    // direcci�n que toma el personaje.
    [SerializeField] private Vector2 direction;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetDirection();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void SetDirection()
    {
        // Cambia la direcci�n seg�n los axis, y las normaliza para que no se sumen las fuerzas cuando se usan a la vez (si fuera en diagonal, ser�a m�s r�pido).
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    private void Move()
    {
        // Cambia la posici�n del personaje seg�n la direcci�n y la velocidad.
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
