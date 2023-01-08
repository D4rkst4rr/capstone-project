using UnityEngine;
using UnityEngine.SceneManagement;

public class delaytonextscene : MonoBehaviour
{
    [SerializeField] private float delay = 10f;
    [SerializeField] private string SceneToload;



    private float timelapsed;

    private void Update()
    {
        timelapsed += Time.deltaTime;

        if (timelapsed > delay)
        {
            SceneManager.LoadScene(SceneToload);
        }
    }
}
