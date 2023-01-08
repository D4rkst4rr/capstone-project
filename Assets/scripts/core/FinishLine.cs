using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject Finishline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Finishline.SetActive(true);
        }
    }
}
