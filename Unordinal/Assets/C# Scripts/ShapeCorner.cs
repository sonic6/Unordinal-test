using UnityEngine;

namespace UnordinalTest 
{
    public class ShapeCorner : MonoBehaviour
    {
        [SerializeField] float size; //Sets the size of the gizmo 

        private void OnDrawGizmos()
        {
            DrawCorner();
            //print(name + " has coordinates " + transform.localPosition);
        }

        //Draws a blue shape corner using wire sphere gizmos
        private void DrawCorner()
        {
            Gizmos.color = Color.blue; //Sets the color of the gizmo
            Gizmos.DrawWireSphere(transform.position, size); //Creates a gizmo in the scene view
        }

        

    }
}

