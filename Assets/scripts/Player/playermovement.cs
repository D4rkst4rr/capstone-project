using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalinput;


    SavePlayer saveplayerdata;   //sa playerpref ni siya nga method sa pagsave
    private void Awake()
    {
        //getting reference for rigidbody and animation object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();


        // PARA NI SA PLAYERPREF METHOD SA PAGSAVE
        saveplayerdata = FindObjectOfType<SavePlayer>();
        saveplayerdata.PlayerPosLoad();
 
    }


    //player movement horizontally
    private void Update()
    {
        //horizontalinput = CrossPlatformInputManager.GetAxis("Horizontal");    // para sa android na control
        horizontalinput = Input.GetAxis("Horizontal");                  // para sa computer nga pagcontrol
        body.velocity = new Vector2(horizontalinput * speed, body.velocity.y);

        //flip player when moving left or right
        if (horizontalinput > 0.01f)
            transform.localScale = new Vector3(0.1395173f, 0.1395173f, 0.1395173f);
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-0.1395173f, 0.1395173f, 0.1395173f);
        //player jump
        //if (CrossPlatformInputManager.GetButtonDown("Jumps") && isGrounded())   // para sa android nga control
        if(Input.GetKey(KeyCode.Space)&& isGrounded())                   // para sa computer nga pagcontrol
   
            jump();
        //Set animator parameter
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isGrounded());


    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpPower);
        anim.SetTrigger("Jump");
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return isGrounded() || !isGrounded();
    }
}
