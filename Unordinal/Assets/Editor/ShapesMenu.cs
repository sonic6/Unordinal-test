using UnityEngine;
using UnityEditor;
using UnordinalTest;
using System.Collections.Generic;

public class ShapesMenu : EditorWindow
{
    List<Transform> corners = new List<Transform>();
    Transform cornerA;
    Transform cornerB;
    Transform cornerC;

    [MenuItem("Window/ShapesWindow")]
    public static void OpenWindow()
    {
        GetWindow(typeof(ShapesMenu));
    }

    

    private void OnGUI()
    {
        GUILayout.Label("Welcome to the Shapes Menu!", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Label("Drag and drop three gameobjects to use as corners of a parallelogram", EditorStyles.boldLabel);
        GUILayout.Label("optional: those gameobjects can be 3 'Corner' prefabs that you could drag into the scene first to use them as corners", EditorStyles.boldLabel);
        EnterShapeCorners();
        
        GUILayout.Space(10);
        GUILayout.Label("Press this button if you want to reset all the parallelogram corners", EditorStyles.boldLabel);
        ResetButton();

        GUILayout.Space(10);
        try { DisplayCoordinates(); }
        catch { Debug.LogWarning("There are no assigned points to get coordinates from");}

        DisplayAboutWindow();
    }

    void DisplayCoordinates()
    {
        GUILayout.Label("The following information changes when the points are moved in the scene ", EditorStyles.boldLabel);

        GUILayout.Label("The area of the parallelogram is " + ParallelogramDrawer.main.GetArea(), EditorStyles.label);
        GUILayout.Label("The area of the circle is " + CircleDrawer.CircleArea(), EditorStyles.label);
        GUILayout.Label("The coordinates of point 1 are (rounded up) " + cornerA.position, EditorStyles.label);
        GUILayout.Label("The coordinates of point 2 are (rounded up)" + cornerB.position, EditorStyles.label);
        GUILayout.Label("The coordinates of point 3 are (rounded up)" + cornerC.position, EditorStyles.label);
        GUILayout.Label("The coordinates of the automatically found fourth point are " + ParallelogramDrawer.main.fourthCorner, EditorStyles.label);
    }

    //Creates three fields where shape corner prefabs can be drag and dropped and submitts them to the parallelogramDrawer
    void EnterShapeCorners()
    {
        cornerA = EditorGUILayout.ObjectField("point 1 of parallelogram", cornerA, typeof(Transform), true) as Transform;
        cornerB = EditorGUILayout.ObjectField("point 2 of parallelogram", cornerB, typeof(Transform), true) as Transform;
        cornerC = EditorGUILayout.ObjectField("point 3 of parallelogram", cornerC, typeof(Transform), true) as Transform;


        corners.Add(cornerA);
        corners.Add(cornerB);
        corners.Add(cornerC);

        if (GUILayout.Button("Submit points"))
        {
            ParallelogramDrawer.main.Corners.Clear();
            foreach (Transform corner in corners)
            {
                ParallelogramDrawer.main.Corners.Add(corner);
            }
        }
        corners.Clear(); //Clears the list so that there are only 3 objects in it in the next execution of this method
    }

    //Creates a reset button in the menu which handles deleting the parallelogram's corners
    void ResetButton()
    {
        if (GUILayout.Button("Reset the board"))
        {
            cornerA = null;
            cornerB = null;
            cornerC = null;
            ParallelogramDrawer.main.Corners.Clear();
        }
    }

    void DisplayAboutWindow()
    {
        GUILayout.Space(50);
        if (GUILayout.Button("About this tool"))
            AboutWindow.OpenWindow();

    }


}
