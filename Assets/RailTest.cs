using UnityEngine;

[ExecuteInEditMode]
public class RailTest : MonoBehaviour {
    public Vector3[] points = new Vector3[0];

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        for (int i = 0; i < points.Length; i++) {
            Gizmos.DrawSphere(points[i], 1f);

            if (i > 0) {
                Gizmos.DrawLine(points[i - 1], points[i]);
            }
        }
    }

}
