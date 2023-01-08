using UnityEngine;

public class spikehead : enemydamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float CheckDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;



    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        //move spike head to destination only if attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else 
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > CheckDelay)
                CheckforPlayer();
        }
    }

    private void CheckforPlayer()
    {
        calculatedirection();
        //check if spikehead detect player
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }

        }
    }

    private void calculatedirection()
    {
        directions[0] = transform.right * range; //right direction
        directions[1] = -transform.right * range; //left direction
        directions[2] = transform.up * range; //up direction
        directions[3] = -transform.up * range; //down direction
    }

    private void Stop()
    {
        destination = transform.position;// set destination to the current position so it doesn't move
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop();
    }
}
