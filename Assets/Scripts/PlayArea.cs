using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayArea : MonoBehaviour
{
    BoxCollider2D boxCollider;
    
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    public Vector3 NextSpawnPoint()
    {
        var bounds = boxCollider.bounds;
        return bounds.center + new Vector3(
            bounds.center.x + (Random.value - 0.5f) * bounds.size.x,
            bounds.center.y + (Random.value - 0.5f) * bounds.size.y,
           0
        );
    }
    
    public static PlayArea Get()
    {
        return GameObject.FindGameObjectWithTag(typeof(PlayArea).Name).GetComponent<PlayArea>();
    }
}