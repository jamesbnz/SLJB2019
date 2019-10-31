using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class ChairLiftTool : MonoBehaviour {
    public AnimationCurve curvature;
    public float curveMultiplier = 1.5f;
    public Color[] samples = { Color.red, Color.blue, Color.green, Color.yellow };
    public Transform t;

    private LineRenderer lr;
    private List<Vector3> positions;
    
    private void Awake() {
        if (curvature == null) {
            curvature = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        }

        GetPositions();

        lr = GetComponent<LineRenderer>();
        lr.positionCount = positions.Count;
        lr.SetPositions(positions.ToArray());

        StartCoroutine(Move());
    }

    private IEnumerator Move() {
        for (int i = 0; i < positions.Count; i++) {
            while (Vector3.Distance(t.position, positions[i + 1]) > 0.5) {
                t.position = Vector3.MoveTowards(t.position, positions[i + 1], Time.deltaTime * 100);

                yield return null;
            }
        }
    }

    void GetPositions() {
        int childCount = transform.childCount;
        positions = new List<Vector3>();

        for (int i = 1; i < childCount; i++) {
            Vector3 start = transform.GetChild(i - 1).position;
            Vector3 end = transform.GetChild(i).position;

            transform.GetChild(i - 1).LookAt(transform.GetChild(i));
            Vector3 down = -transform.GetChild(i - 1).up * curveMultiplier;
            
            float fraction = 1 / samples.Length;

            Vector3 b = Vector3.zero;
            for (int j = 0; j < samples.Length; j++) {
                Vector3 a = Vector3.Lerp(start, end, 0.25f * j) + (down * curvature.Evaluate(j / (float)samples.Length));
                b = Vector3.Lerp(start, end, 0.25f * (j + 1)) + (down * curvature.Evaluate((j + 1) / (float)samples.Length));

                positions.Add(a);
            }

            if (i == childCount - 1) {
                positions.Add(b);
            }
        }

        if (!lr) {
            lr = GetComponent<LineRenderer>();
        }
        
        lr.SetPositions(positions.ToArray());
    }

    private void OnDrawGizmos() {
        GetPositions();

        for (int i = 0; i < positions.Count; i++) {
            Gizmos.color = samples[i % samples.Length];
            if (i < positions.Count - 1) {
                Gizmos.DrawLine(positions[i], positions[i + 1]);
            }
            
            Gizmos.DrawSphere(positions[i], 0.1f);
        }
    }
}
