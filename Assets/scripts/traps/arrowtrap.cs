using UnityEngine;

public class arrowtrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldowntimer;

    private void attack()
    {
        cooldowntimer = 0;

        arrows[Findarrows()].transform.position = firepoint.position;
        arrows[Findarrows()].GetComponent<Enemyprojectile>().ActiveProjectile();
    }
    private int Findarrows()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;

        if (cooldowntimer >= attackCooldown)
            attack();
    }
}
