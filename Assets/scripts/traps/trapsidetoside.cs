using UnityEngine;

public class trapsidetoside : MonoBehaviour
{
    [SerializeField] private float MovementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingleft;
    private float leftedge;
    private float rightedge;



    private void Awake()
    {
        leftedge = transform.position.x - MovementDistance;
        rightedge = transform.position.x + MovementDistance;
    }
    private void Update()
    {
        // saw movement from left to right;
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = false;
        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
