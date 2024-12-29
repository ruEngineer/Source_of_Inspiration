using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ScreenCapture.CaptureScreenshot("screenshot" + System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)") + ".png");
        }
    }
}
