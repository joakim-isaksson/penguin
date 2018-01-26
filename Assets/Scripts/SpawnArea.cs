using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnArea : MonoBehaviour
{
    BoxCollider2D boxCollider;
    
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    public Vector3 GetRandomSpawnPoint()
    {
        var bounds = boxCollider.bounds;
        return bounds.center + new Vector3(
            bounds.center.x + (Random.value - 0.5f) * bounds.size.x,
            bounds.center.y + (Random.value - 0.5f) * bounds.size.y,
           0
        );
    }
    
    public static SpawnArea Get()
    {
        return GameObject.FindGameObjectWithTag(typeof(SpawnArea).Name).GetComponent<SpawnArea>();
    }
}