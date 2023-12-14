using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Volume volume;
    private Bloom bloom;

    public float targetBloomIntensity = 200f;
    public float transitionDuration = 2f;

    private float initialBloomIntensity;
    private float elapsedTime = 0f;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PlayGame()
    {
        volume.profile.TryGet(out bloom);
        // Store the initial bloom intensity
        initialBloomIntensity = bloom.intensity.value;

        // Start the coroutine to smoothly increase bloom intensity
        StartCoroutine(IncreaseBloomOverTime());
        StartCoroutine(PlayGameScene());
    }
    IEnumerator PlayGameScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator IncreaseBloomOverTime()
    {
        while (elapsedTime < transitionDuration)
        {
            // Interpolate between initial and target bloom intensity
            bloom.intensity.value = Mathf.Lerp(initialBloomIntensity, targetBloomIntensity, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the target value is reached exactly
        bloom.intensity.value = targetBloomIntensity;
    }

    // This method is called when the "Quit" button is pressed in the main menu.
    public void QuitGame()
    {
        // Quit the application. Note that this may not work in all environments.
        Application.Quit();
    }
}
