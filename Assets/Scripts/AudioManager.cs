using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer audioMixer;

    private float masterVolume = 1f;
    public bool isMuted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadVolumeSettings();
    }

    // M�todo para ajustar el volumen maestro
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        SaveVolumeSettings();
    }

    // M�todo para cargar la configuraci�n de volumen almacenada
    private void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        SetMasterVolume(masterVolume);
    }

    // M�todo para guardar la configuraci�n de volumen
    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }

    // M�todo para activar o desactivar el volumen
    public void ToggleVolume()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            SetMasterVolume(0f);
        }
        else
        {
            SetMasterVolume(1f);
        }
    }
}
