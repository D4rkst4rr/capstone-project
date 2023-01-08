using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    //dynamite
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    public projectile dynamite;
    private Animator anim;
    private playermovement PlayerMovement;
    private float cooldownTimer = Mathf.Infinity;

    //melee
    [SerializeField] private Transform meleeattackpoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField]private float attackRange;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<playermovement>();
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Throw") && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("Melee"))
            meleeAttack();
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        Instantiate(dynamite, firepoint.position, firepoint.rotation).throwDir
            = new Vector2(transform.localScale.x, transform.localScale.y);
    }
    private void meleeAttack()
    {
        // play attack animation
        anim.SetTrigger("meleeAttack");
        
    }
    private void OnDrawGizmosSelected()
    {
        if (meleeattackpoint == null)
            return;

        Gizmos.DrawWireSphere(meleeattackpoint.position, attackRange);
    }
    // for animation event
    public void meleeeattack()
    {
        // detect enemies
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(meleeattackpoint.position, attackRange, enemyLayers);
        // damage enemies
        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Health>().TakeDamage(1);

        }
    }
}
