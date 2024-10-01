using System;
using UnityEngine;

public class VectorThing : MonoBehaviour
{

    public Transform aTf;
    public Transform bTf;

    public float abDist;

    void OnDrawGizmos() {
      Vector2 pt = transform.position;

      Vector2 a = aTf.position;
      Vector2 b = bTf.position;


      Vector2 aToB = b - a;
      Vector2 aToBDir = aToB.normalized;

      Gizmos.DrawLine(a, a + aToBDir);
      abDist = Vector2.Distance(a, b);
    }
}
