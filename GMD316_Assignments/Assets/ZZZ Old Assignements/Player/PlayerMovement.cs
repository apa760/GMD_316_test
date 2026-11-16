using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    Vector2 movement;

    public ParticleSystem propParticles;

    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

   void Update()
   {
       // Get input from player
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
   }
   void FixedUpdate()
   {
       // Apply movement to the Rigidbody2D
       rb.MovePosition(rb.position + movement * playerStats.currentMoveSpeed * Time.fixedDeltaTime);
   }
}
