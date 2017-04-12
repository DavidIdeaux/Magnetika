#region Author
/*
     
     Jones St. Lewis Cropper (caLLow)
     
     Another caLLowCreation
     
     Visit us on Google+ and other social media outlets @caLLowCreation
     
     Thanks for using our product.
     
     Send questions/comments/concerns/requests to 
      e-mail: caLLowCreation@gmail.com
      subject: ValueConstraints
     
*/
#endregion

using TryItCompatibilityEditor;
using UnityEditor;
using UnityEngine;
using ValueConstraints;

namespace ValueConstraintsEditor
{
    /// <summary>
    /// Opens example scene picker
    /// </summary>
    [InitializeOnLoad]
    internal sealed class OpenScenesEditorWindow
    {
        static OpenScenesEditorWindow()
        {
            //Debug.Log("OpenScenesEditorWindow UpdateShowPrompt");
            ExampleScenesWindow.newsletterSignupUrl = "http://eepurl.com/bPDq3P";
            ExampleScenesWindow.isFullVersion = !ValueConstraintsSettings.Instance.GetTryIt();
            ExampleScenesWindow.packageName = "Value Constraints";
            ExampleScenesWindow.buttonTexts = new SceneButton[]
            {
                new SceneButton("Open Main 2D Scene", "Main 2D Scene", "Assets/ValueConstraints/Scenes/Main 2D Scene.unity",
                    "Value Constraints was designed to work with both 2D and 3D. The 2D and 3D components can be used together in the same scene."),
                new SceneButton("Open Main 3D Scene", "Main 3D Scene", "Assets/ValueConstraints/Scenes/Main 3D Scene.unity",
                    "Moving an object is as easy as it gets. Create waypoints and manipulate them in the scene view to get just the right feel.  Use Value Constraints to lerp between colors, materials, Vectors and a whole lot more."),
                new SceneButton("Open Track 2D Scene", "Track 2D Scene", "Assets/ValueConstraints/Scenes/Track 2D Scene.unity",
                    "Like the built in RangeAttribute, LimitsControlAttribute and the LimitsFloat class provide a slider to select a number between a min and max range, a current value and the ability to randomize, pingpong and wrap the values based on custom conditions."),
            };

            ExampleScenesWindow.fullVersionUrl = "http://u3d.as/m3r";
        }

        [MenuItem("Window/Value Constraints/Example Scenes")]
        internal static void Init()
        {
            ExampleScenesWindow.Init();
        }
    }
}