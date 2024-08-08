using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickedButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip;
    [SerializeField] private AudioSource _source;
    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_compressClip);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneDelay());
    }

    IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        PlayGame();
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameDelay());
        Debug.Log("Quit!");
    }

    IEnumerator QuitGameDelay()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        ExitGame();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Application.Quit();
    }


}
