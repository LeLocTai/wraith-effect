using System;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ScreenshotWizard : ScriptableWizard
{
    public string folder    = "Screenshots";
    public int    supersize = 1;

    readonly Rect shootBtnRect = new Rect(0, 0, 100, 20);

    [MenuItem("Tools/Screenshot %#&s")] static void CreateWizard()
    {
        DisplayWizard<ScreenshotWizard>("Take Screenshots", "");
    }

    protected override bool DrawWizardGUI()
    {
        bool modified = base.DrawWizardGUI();

//        if(GUI.Button(shootBtnRect, ))
        if (GUILayout.Button("Shoot"))
        {
            TakeScreenshot();
        }

        return modified;
    }

    void TakeScreenshot()
    {
        var fileName = string.Format(
            "{0}/{1}_{2}_{3:yyyy-MM-dd_HH.mm.ss.ffff}.png",
            folder,
            PlayerSettings.productName,
            SceneManager.GetActiveScene().name,
            DateTime.Now
        );

        ScreenCapture.CaptureScreenshot(fileName, supersize);
        Debug.Log($"Captured {fileName}");
    }
}
