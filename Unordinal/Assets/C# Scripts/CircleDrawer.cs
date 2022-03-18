using UnityEngine;

namespace UnordinalTest
{
    public class CircleDrawer : MonoBehaviour
    {
        [HideInInspector] public ParallelogramDrawer parallelogramDrawer; //a reference to the main ParallelogramDrawer in the scene

        private void OnDrawGizmos()
        {
            DrawCircle();
        }

        //Finds the radius of the circle that will be drawn using coordinates from a parallelogram
        private static float FindRadius()
        {
            float parallelogramArea = ParallelogramDrawer.main.GetArea();
            float radius = Mathf.Sqrt(parallelogramArea / Mathf.PI);
            return radius;
        }

        //Draws a circle that has the same center of a previously drawn parallelogram
        private void DrawCircle()
        {
            Gizmos.color = Color.yellow;


            float angle = 0;
            float x = FindRadius() * Mathf.Cos(angle);
            float y = FindRadius() * Mathf.Sin(angle);

            Vector2 pos = parallelogramDrawer.FindCenter() + new Vector2(x, y);
            Vector2 newPos;
            Vector2 lastPos = pos;
            for (angle = 0.1f; angle < Mathf.PI * 2; angle += 0.1f)
            {
                x = FindRadius() * Mathf.Cos(angle);
                y = FindRadius() * Mathf.Sin(angle);
                newPos = parallelogramDrawer.FindCenter() + new Vector2(x, y);
                Gizmos.DrawLine(pos, newPos);
                pos = newPos;
            }
            Gizmos.DrawLine(pos, lastPos);
        }

        //Finds the area of the drawn circle
        public static float CircleArea()
        {
            float area = Mathf.PI * Mathf.Pow(FindRadius(), 2);
            return area;
        }
    }
    

}

