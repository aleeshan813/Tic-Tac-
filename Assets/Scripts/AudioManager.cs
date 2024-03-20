using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSound;
    [SerializeField] AudioSource sfxSound;

    [Header("-------- Audio Clip --------")]
    public AudioClip GameStrt;
    public AudioClip Winner;
    public AudioClip Click;

    public static AudioManager Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSound.PlayOneShot(clip);
    }

    public void PlaymusicSound(AudioClip clip)
    { 
        musicSound.PlayOneShot(clip);
    }

}
