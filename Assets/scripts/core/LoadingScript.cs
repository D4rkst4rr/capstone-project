using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LoadingScript : MonoBehaviour
{
    public static LoadingScript Instance;

    [SerializeField] private GameObject loadercanvas;
    [SerializeField] private Image progressbar;
    private float target;


void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject); 
        }
        
    }

    
public async void LoadScenes(string SceneName) 
    {
        target = 0;
        progressbar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(SceneName);
        scene.allowSceneActivation = false;

        loadercanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        loadercanvas.SetActive(false);

    }
    private void Update()
    {
        progressbar.fillAmount = Mathf.MoveTowards(progressbar.fillAmount, target, 3 * Time.deltaTime);
    }
}
