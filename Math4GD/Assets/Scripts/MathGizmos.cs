using UnityEngine;

public class MathGizmos : MonoBehaviour
{
    public Transform A;
    public Transform B;

    public float scProj;

    // draw in scene view
    private void OnDrawGizmos()
    {
        Vector2 a = A.position;
        Vector2 b = B.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, a);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(default, b);

        // Normalize A and draw it
        // manual version
        // float aLength = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        // float aLength = a.magnitude; // sqrt is faster because it doesnt have the overhead that comes with calling a method, but magnitude is more readable
        // Vector2 aNorm = a/ aLength;

        // quick and easy version
        Vector2 aNorm = a.normalized;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aNorm, 0.05f);

        // Scalar Projection
        scProj = Vector2.Dot(aNorm, b); // order does not matter when using Dot Product, but it does when using Cross Product

        // Vector Projection
        Vector2 vecProj = aNorm * scProj;

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(vecProj, 0.05f);
        Gizmos.DrawLine(b, vecProj);
    }
}
