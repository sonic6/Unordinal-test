using UnityEngine;

public class ShapeCorner : MonoBehaviour
{
    [SerializeField] float size; //Sets the size of the gizmo 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue; //Sets the color of the gizmo
        Gizmos.DrawWireSphere(transform.position, size); //Creates a gizmo in the scene view
    }
}
