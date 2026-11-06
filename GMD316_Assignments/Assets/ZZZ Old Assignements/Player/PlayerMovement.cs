using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

   public float moveSpeed = 10f;
   public Rigidbody2D rb;
   Vector2 movement;


   void Update()
   {
       // Get input from player
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
   }
   void FixedUpdate()
   {
       // Apply movement to the Rigidbody2D
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
   }
}
