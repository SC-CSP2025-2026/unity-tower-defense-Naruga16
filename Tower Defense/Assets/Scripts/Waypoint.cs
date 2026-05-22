using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [field: SerializeField]
    public Waypoint Next {get; private set;}

    void OnDrawGizmoSelected() 
    {
        Handles.color = Color.red;
        Handles.DrawLine(transform.positon, Next.transform.positon, 3f);
    }
}
