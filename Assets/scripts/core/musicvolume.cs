using UnityEngine;
using UnityEngine.UI;

public class musicvolume : MonoBehaviour
{
    [SerializeField] Slider volumeslider;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeslider.value;
        save();
    }
    private void Load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeslider.value);
    }
}
