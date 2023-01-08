using UnityEngine;

public class playerdataholder : MonoBehaviour
{
    public GameObject player;
    public float health;

    private void playerdatus()
    {
        health = player.GetComponent<Health>().currentHealth;
    }
    public void savePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.healthHP;

        Vector2 position;
        position.x = data.positions[0];
        position.y = data.positions[1];
        transform.position = position;

        
    }
}
