using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");

    //Klasa sluzi da proveri kretanje maria. primer: Vector2.down proverava da li je igrac na zemlji pri pozivu
    //primer: Vector2.right ili Vector2.left proveravaju da li igrac udara u zid
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }
    //proverava da li transform nailazi na drugi transform pri kretanju. 
    //primer: gazenje neprijatelja prolazi kroz player transform, enemy transform i vector2.down
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

}
