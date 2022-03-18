using UnityEditor;
using UnityEngine;

public class AboutWindow : EditorWindow
{
    public static void OpenWindow()
    {
        GetWindow(typeof(AboutWindow));
    }

    private void OnGUI()
    {
        string message = "This tool is used to draw a parallelogram in the scene view \n" +
            "it also finds the center of this parallelogram and draws\n" +
            " a circle that shares the same center point and area";

        string usage = "Insert three gameobjects from the scene into the provided fields in the ShapesWindow " +
            "then click sumbit. This will cause those three gameobjects to be used as three corners of " +
            "a parallelogram that gets drawn in the scene window. " +
            "you could also drag in the prefab 'Corner' into the scene to use as a corner. The difference " +
            "is that this prefab also displays a wireframe sphere at each corner";

        string toolComponents = "Please make sure that one gameobject in the scene has the components 'ParallelogramDrawer' and" +
            " 'CircleDrawer' before using the 'Submit points' button in the ShapesMenu";

        GUILayout.Label("Author: ", EditorStyles.label);
        GUILayout.Label("This tool was made by Ahmad Al Shehabi", EditorStyles.helpBox);
        GUILayout.Space(10);

        GUILayout.Label("About: " , EditorStyles.label);
        GUILayout.Label(message, EditorStyles.helpBox);
        GUILayout.Space(10);

        GUILayout.Label("Component scripts ", EditorStyles.label);
        GUILayout.Label(toolComponents, EditorStyles.helpBox);
        GUILayout.Space(10);

        GUILayout.Label("How to use: ", EditorStyles.label);
        GUILayout.Label(usage, EditorStyles.helpBox);

        
    }
}

