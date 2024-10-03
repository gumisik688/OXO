using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider slider;

    public void Play(int sceneIndex)
    {
        StartCoroutine(LoadAsyncchronously(sceneIndex));
        Time.timeScale = 1;
    }

    IEnumerator LoadAsyncchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScene.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
