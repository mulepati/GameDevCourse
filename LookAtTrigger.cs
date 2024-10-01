using UnityEngine;
using UnityEditor;

public class LookAtTrigger : MonoBehaviour
{
    public Transform playerLook;

    public Transform trigger;

    public float looking = 0f;

    void OnDrawGizmos() {
      // Positions
      Vector2 origin = transform.position;
      Vector2 lookPosition = playerLook.position;
      Vector2 triggerPosition = trigger.position;

      Vector2 lookDirection = (lookPosition - origin).normalized;

      Vector2 playerToTrigger = (triggerPosition - origin).normalized;
      looking = Vector2.Dot(lookDirection, playerToTrigger);
      bool isLooking = looking >= 0f;
      Handles.color = isLooking ? Color.green : Color.red;

      Handles.DrawLine(origin, origin + lookDirection, 3f);
      Handles.DrawDottedLine(origin, triggerPosition, 2f);
    }
}
