using UnityEngine;

public class UtilisMethod
{
    public static bool isGrounded(Transform t , float radius, LayerMask l)
    {
        return Physics2D.OverlapCircle(t.position, radius, l);
    }
}
