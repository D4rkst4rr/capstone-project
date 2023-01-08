using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public float healthHP;
    public float[] positions;

    public PlayerData (playerdataholder player)
    {
        healthHP = player.health;
      
        positions = new float[2];
        positions[0] = player.transform.position.x;
        positions[1] = player.transform.position.y;
    }
}
