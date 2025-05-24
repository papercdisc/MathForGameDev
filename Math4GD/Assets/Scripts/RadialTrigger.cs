using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadialTrigger : MonoBehaviour
{
    public List<Transform> targets; // the "player" object

    public float radius = 5f; // the radius of the trigger

    bool CheckIfInRadius()
    {
        if (targets.Count < 1) return false;

        // if distance from object is greater than radius, its not within the radius
        foreach(Transform target in targets)
        {
            float disFromTarget = Vector2.Distance(target.position, transform.position);
            if (disFromTarget < radius)
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        if (targets.Count >= 1)
        {
            if (CheckIfInRadius())
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    public void AddTarget(Transform target)
    {
        if (targets.Count >= 1)
        {
            foreach (Transform t in targets)
            {
                if (t == target) return; // if the target is already in the list, do not add it again
            }
        }

        targets.Add(target);
    }
}
