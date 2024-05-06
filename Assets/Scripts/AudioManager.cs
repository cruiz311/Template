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

    // Método para ajustar el volumen maestro
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        SaveVolumeSettings();
    }

    // Método para cargar la configuración de volumen almacenada
    private void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        SetMasterVolume(masterVolume);
    }

    // Método para guardar la configuración de volumen
    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.Save();
    }

    // Método para activar o desactivar el volumen
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
