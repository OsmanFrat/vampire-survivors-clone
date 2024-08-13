using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip levelUpSoundEffect;
    [SerializeField] private AudioClip gameOverSoundEffect;
    [SerializeField] private AudioClip eatingSoundEffect;
    [SerializeField] private AudioClip expSoundEffect;
    [SerializeField] private AudioClip[] hitSounds;

    [SerializeField] private CollideWithItem collideItemScript;
    [SerializeField] private GameManager gameManager;

    private const float DefaultMusicVolume = 0.5f;
    private const float DefaultSfxVolume = 0.5f;

    private void Start()
    {
        InitializeVolumeSettings();
        //Load();
    }

    private void Update()
    {
        HandleSoundEffects();
    }

    private void InitializeVolumeSettings()
    {
        //if (!PlayerPrefs.HasKey("musicVolume"))
        //    PlayerPrefs.SetFloat("musicVolume", DefaultMusicVolume);

        //if (!PlayerPrefs.HasKey("soundEffectsVolume"))
        //    PlayerPrefs.SetFloat("soundEffectsVolume", DefaultSfxVolume);

        // Load slider values from PlayerPrefs
        bgmSlider.value = PlayerPrefs.GetFloat("musicVolume", bgmSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume", sfxSlider.value);
    }

    public void ChangeVolume()
    {
        // Update audio source volumes based on slider values
        bgmSource.volume = bgmSlider.value;
        sfxSource.volume = sfxSlider.value;

        // Save updated volume settings
        Save();
    }

    private void Load()
    {
        // Set audio source volumes based on loaded values
        bgmSource.volume = PlayerPrefs.GetFloat("musicVolume", bgmSlider.value);
        sfxSource.volume = PlayerPrefs.GetFloat("soundEffectsVolume", sfxSlider.value);

    }

    private void Save()
    {
        // Save current slider values to PlayerPrefs
        PlayerPrefs.SetFloat("musicVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("soundEffectsVolume", sfxSlider.value);
    }

    private void HandleSoundEffects()
    {
        if (collideItemScript.playEatingSfx)
        {
            EatingSfx();
            collideItemScript.playEatingSfx = false;
        }

        if (collideItemScript.playExpSfx)
        {
            ExpSfx();
            collideItemScript.playExpSfx = false;
        }

        if (gameManager.playLevelUpSfx)
        {
            LevelUpSfx();
            gameManager.playLevelUpSfx = false;
        }

        if (gameManager.playGameOverSfx)
        {
            GameOverSfx();
            gameManager.playGameOverSfx = false;
        }
    }

    public void LevelUpSfx()
    {
        sfxSource.PlayOneShot(levelUpSoundEffect);
    }

    public void GameOverSfx()
    {
        sfxSource.PlayOneShot(gameOverSoundEffect);
    }

    public void ExpSfx()
    {
        sfxSource.PlayOneShot(expSoundEffect);
    }

    public void EatingSfx()
    {
        sfxSource.PlayOneShot(eatingSoundEffect);
    }

    public void HitSfx()
    {
        AudioClip selectedClip = hitSounds[Random.Range(0, hitSounds.Length)];
        sfxSource.PlayOneShot(selectedClip);
    }
}
