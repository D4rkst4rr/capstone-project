using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;


    [Header("Iframes")]
    [SerializeField] private float Iframesduration;
    [SerializeField] private int numberofflashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;


    public GameOverScript Gameoverscreen;

 
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                //deactivate all attach components
                foreach (Behaviour component in components)
                component.enabled = false;
                dead = true;
                Gameoverscreen.Setup();
            }

        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
                yield return new WaitForSeconds(Iframesduration / (numberofflashes * 2));
                spriteRend.color = Color.white;
                 yield return new WaitForSeconds(Iframesduration / (numberofflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
