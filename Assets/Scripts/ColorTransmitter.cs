using UnityEngine;

[RequireComponent(typeof(Player))]
public class ColorTransmitter : MonoBehaviour
{
    public float MaxDistance;
    
    Player player;
    Player target;

    LineRenderer line;
    Collider2D[] collisions;
    Player[] candidates;
    
    void Awake()
    {
        player = GetComponent<Player>();
        enabled = player.IsLocal;

        collisions = new Collider2D[GameController.Get().MaxNumberOfPlayers];
        candidates = new Player[collisions.Length];
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        // Cancel transmitting
        if (player.Moving || target != null && (target.Moving ||
            Vector2.Distance(player.transform.position, target.transform.position) > MaxDistance))
        {
            line.enabled = false;
            player.Transmiting = false;
            target = null;
            return;
        }

        if (target == null)
        {
            line.enabled = false;
            player.Transmiting = false;
        }
        else if (player.Transmiting)
        {
            line.SetPosition(0, player.transform.position);
            line.SetPosition(1, target.transform.position);
            return;
        }
        
        // Find targets for transmission
        var hits = Physics2D.OverlapCircleNonAlloc(player.transform.position, MaxDistance, collisions);
        var targetCount = 0;
        for (var i = 0; i < hits; ++i)
        {
            var other = collisions[i].GetComponent<Player>();
            if (other == null || other == player) continue;
            if (!other.Moving) candidates[targetCount++] = other;
        }
        if (targetCount == 0) return;
        
        // Choose the closest target
        var minDistance = float.MaxValue;
        for (var i = 0; i < targetCount; ++i)
        {
            var dist = Vector2.Distance(player.transform.position, candidates[i].transform.position);
            if (dist > minDistance) continue;
            minDistance = dist;
            target = candidates[i];
        }
        if (target == null) return;
        
        // Start transmiting
        player.Transmiting = true;
        line.SetPosition(0, player.transform.position);
        line.SetPosition(1, target.transform.position);
        line.startColor = Color.blue;
        line.endColor = Color.blue;
        line.enabled = true;
    }
}