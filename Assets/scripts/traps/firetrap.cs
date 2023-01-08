using UnityEngine;
using System.Collections;

public class firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Fire Timer")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trap gets triggerd
    private bool active; // when the trap is active

    private Health playerHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());  
            }
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn the trap sprite color red to notify player
        triggered = true;
        spriteRend.color = Color.red; 

        //create a delay to activate the trap, turn on animation
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //make the trap sprite color back to normal
        active = true;
        anim.SetBool("Activated", true);

        //wait until x seconds, deactivate trap and reset varibales and animations
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("Activated", false);
    }
}
