using UnityEngine;

public class Enemyprojectile : enemydamage // will damage the player every time they touch
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActiveProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);

    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);//execute logic from parent script first
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("explode"); // when the object is bullet
        else
            gameObject.SetActive(false); //deactivate arrow when hit object
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
