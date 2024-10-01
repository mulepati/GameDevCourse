using UnityEngine;
using UnityEditor;

public class WorldToLocal : MonoBehaviour
{
  public Transform local;

  public Transform point;

  public bool worldToLocal = false;

  public bool localToWorld = false;

  void OnDrawGizmos() {
    Vector2 worldOrigin = transform.position;
    Vector2 localOrigin = local.position;
    Vector2 pointPose = point.position;

    Gizmos.DrawSphere(point.position, 1);

    if (worldToLocal) {
      Debug.Log("x values " + pointPose.x + " " + Vector2.Dot(transform.right, local.right));
      float xPoint = pointPose.x * Vector2.Dot(transform.right, local.right);
      float yPoint = pointPose.y * Vector2.Dot(transform.up, local.up);

      xPoint = xPoint + (localOrigin.x - worldOrigin.x);
      yPoint = yPoint + (localOrigin.y - worldOrigin.y);

      point.position = new Vector3(xPoint, yPoint, 0);

      worldToLocal = false;
    }

    if (localToWorld) {
      float xPoint = pointPose.x * Vector2.Dot(transform.right, local.right);
      float yPoint = pointPose.y * Vector2.Dot(transform.up, local.up);

      xPoint = xPoint + (worldOrigin.x - localOrigin.x);
      yPoint = yPoint + (worldOrigin.y - localOrigin.y);

      point.position = new Vector3(xPoint, yPoint, 0);

      localToWorld = false;
    }
  }
}
