using UnityEngine;
using UnityEditor;

public class Trigger : MonoBehaviour
{
    public Transform player;

    [Range(0f, 4f)]
    public float radius = 1f;

    void OnDrawGizmos() {

      Vector2 triggerPosition = transform.position;

      Vector2 playerPosition = player.position;

      // Naive solution:
      // float distToPlayer = Vector2.Distance(playerPosition, triggerPosition);

      // bool inTrigger = distToPlayer < radius;

      // Optimized solution to take into accoutn cost of square root:

      Vector2 originToPlayer = playerPosition - triggerPosition;
      float distSq = originToPlayer.x * originToPlayer.x + originToPlayer.y * originToPlayer.y;

      bool inTrigger = distSq < radius * radius;

      Handles.color = inTrigger ? Color.red : Color.green;

      Handles.DrawWireDisc(triggerPosition,  new Vector3(0, 0, 1), radius);
    }
}
