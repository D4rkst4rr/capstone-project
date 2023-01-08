using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private Rigidbody2D rb2d;
    public float throwforce;
    public Vector2 throwDir;
    bool isThrown;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isThrown = true;
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isThrown == true)
        {
            rb2d.AddForce(throwDir * throwforce, ForceMode2D.Impulse);
            isThrown = false;
        }
    }

    // when the bomb hit colliders it explodes
    private void OnTriggerEnter2D(Collider2D collision)
    {
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            rb2d.velocity = Vector2.zero;
        rb2d.gravityScale = 0;


        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1);

    }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        boxCollider.enabled = true;

        //when player face R or Left the bomb firepoint is move to that directin
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
