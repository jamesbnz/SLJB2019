using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class GizmoDesign : MonoBehaviour {
    private void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0);
        Vector3 start = transform.position - (transform.forward * transform.localScale.magnitude);
        Vector3 end = transform.position + (transform.forward * transform.localScale.magnitude);
        
        Gizmos.DrawLine(
            start
        ,   end
        );

        Handles.DrawAAPolyLine(20, new Vector3[] {
            start,
            end
        });
    }
}
