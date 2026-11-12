using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float _bulletSpeed;
    public float currentBulletSpeed;


    public float lifespan = 3.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


        SetBulletData();
    }


    void FixedUpdate()
    {
        if(rb != null)
        {
            rb.MovePosition(rb.position + Vector2.right * currentBulletSpeed * Time.fixedDeltaTime);
        }

        lifespan -= Time.fixedDeltaTime;
        if(lifespan < 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void SetBulletData()
    {
        currentBulletSpeed = _bulletSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
