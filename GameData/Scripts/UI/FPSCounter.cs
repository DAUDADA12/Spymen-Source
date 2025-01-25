using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsDisplay;
    public int avgFrameRate;
    private float deltaTime = 0.0f;

    public void Update()
    {
        // Calculate the time between frames
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Calculate FPS
        float fps = 1.0f / deltaTime;

        // Display FPS as an integer in the Text component
        fpsDisplay.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
