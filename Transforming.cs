using UnityEngine;
using UnityEditor;

public class Transforming : MonoBehaviour
{

  public Vector2 localPoint;

  public Vector2 worldPoint;

  void OnDrawGizmos() {
    Vector2 objPos = transform.position;
    Vector2 objUp = transform.up;
    Vector2 objRight = transform.right;

    DrawSpace(objPos, objRight, objUp);
    DrawSpace(new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1));

    Vector2 worldPosFromLocalPoint = LocalToWorld(localPoint);

    Gizmos.DrawSphere(worldPosFromLocalPoint, 0.1f);

    Gizmos.DrawSphere(worldPoint, 0.2f);
  }

  void DrawSpace(Vector2 pos, Vector2 right, Vector2 up) {
    Gizmos.color = Color.red;
    Gizmos.DrawRay(pos, right);
    Gizmos.color = Color.green;
    Gizmos.DrawRay(pos, up);
    Gizmos.color = Color.white;
  }

  Vector2 LocalToWorld(Vector2 local) {
    Vector2 pos = transform.position;

    pos.x += local.x * transform.right.x;
    pos.y += local.y * transform.up.y;

    return pos;
  }

  Vector2 WorldToLocal(Vector2 world) {
    Vector2 pos = world - (Vector2) transform.position;

    float x = Vector2.Dot(pos, (Vector2)transform.right);
    float y = Vector2.Dot(pos, (Vector2)transform.up);

    return new Vector2(x, y);
  }
}
