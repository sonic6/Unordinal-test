using System.Collections.Generic;
using UnityEngine;

namespace UnordinalTest
{
    
    public class CircleDrawer : MonoBehaviour
    {
        public ParallelogramDrawer par;
        Vector2 center;

        private void OnDrawGizmos()
        {
            DrawCircle();
            CircleArea();
        }

        //Finds the radius of the circle that will be drawn using coordinates from a parallelogram
        private float FindRadius()
        {
            center = par.FindCenter();
            return Vector2.Distance(center, par.fourthCorner);
        }

        //Draws a circle that has the same center of a previously drawn parallelogram
        private void DrawCircle()
        {
            Gizmos.color = Color.yellow;


            float angle = 0;
            float x = FindRadius() * Mathf.Cos(angle);
            float y = FindRadius() * Mathf.Sin(angle);

            Vector2 pos = par.FindCenter() + new Vector2(x, y);
            Vector2 newPos = pos;
            Vector2 lastPos = pos;
            for (angle = 0.1f; angle < Mathf.PI * 2; angle += 0.1f)
            {
                x = FindRadius() * Mathf.Cos(angle);
                y = FindRadius() * Mathf.Sin(angle);
                newPos = center + new Vector2(x, y);
                Gizmos.DrawLine(pos, newPos);
                pos = newPos;
            }
            Gizmos.DrawLine(pos, lastPos);
        }

        //Finds the area of the drawn circle
        void CircleArea()
        {
            float area = Mathf.PI * Mathf.Pow(FindRadius(),2);
            print("circle area is " + area);
        }
    }
    

}

