using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    
    public bool SceneStarting { get; private set; }
    public bool SceneEnding { get; private set; }

    private string destinationSceneName;

    void Awake()
    {
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Start()
    {
        SceneStarting = true;
        SceneEnding = false;
    }

    void Update()
    {
        if (SceneStarting)
        {
            StartScene();
        }
        else if (SceneEnding)
        {
            EndScene();
        }
    }

    public void GotoScene(string sceneName)
    {
        SceneStarting = false;
        SceneEnding = true;
        destinationSceneName = sceneName;
    }

    void StartScene()
    {
        FadeToClear();

        if (guiTexture.color.a <= 0.15f)
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;

            SceneStarting = false;
        }
    }

    void EndScene()
    {
        guiTexture.enabled = true;

        FadeToBlack();

        if (guiTexture.color.a >= 0.85f)
        {
            Application.LoadLevel(destinationSceneName);
        }
    }

    void FadeToClear()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
