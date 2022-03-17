using System.Collections.Generic;
using UnityEngine;

namespace UnordinalTest
{
    public class ParallelogramDrawer : MonoBehaviour
    {
        [SerializeField] List<Transform> Corners = new List<Transform>();
        Vector2 CornerA;
        Vector2 CornerB;
        Vector2 CornerC;
        public Vector2 fourthCorner { get; private set; }

        private void OnDrawGizmos()
        {
            DrawParallelogram();
        }

        private void DrawParallelogram()
        {
            fourthCorner = FindFourthCorner();

            //Draws a line from point 1 (index 2) to point 2 (index 0)
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(CornerC, CornerA);

            //Draws a line from point 2 (index 0) to point 3 (index 1)
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(CornerA, CornerB);

            //Draws a line from point 3 (index 1) to point 4 (fourthCorner)
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(CornerB, fourthCorner);

            //Draws a line from point 4 (fourthCorner) to point 1 (index 2)
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(fourthCorner, CornerC);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(fourthCorner, .2f);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(FindCenter(), .2f);

            print("fourth corner has coordinates " + fourthCorner);
        }

        //Finds the fourth point that the parallelogram is made of
        private Vector2 FindFourthCorner()
        {
            CornerA = new Vector2(Corners[0].localPosition.x, Corners[0].localPosition.y);
            CornerB = new Vector2(Corners[1].localPosition.x, Corners[1].localPosition.y);
            CornerC = new Vector2(Corners[2].localPosition.x, Corners[2].localPosition.y);

            Vector2 slopeAB = new Vector2((CornerB.x - CornerA.x), (CornerB.y - CornerA.y));
            Vector2 cornerD = new Vector2((CornerC.x + slopeAB.x), (CornerC.y + slopeAB.y));

            return cornerD;
        }

        /// <summary>
        /// Finds the 2D space coordinates for the center point of the parallelogram
        /// </summary>
        /// <returns></returns>
        public Vector2 FindCenter()
        {
            float centerX = (CornerC.x + CornerB.x) / 2;
            float centerY = (CornerC.y + CornerB.y) / 2;
            return new Vector2(centerX, centerY);
        }

        void GetArea()
        {

        }


    }
}
