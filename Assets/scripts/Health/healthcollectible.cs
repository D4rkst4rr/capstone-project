using UnityEngine;

public class healthcollectible : MonoBehaviour
{
    [SerializeField] private float healthvalue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthvalue);
            gameObject.SetActive(false);

        }
    }
}
