using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderGenerator : MonoBehaviour
{
    public static void CreateLadder(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer)
    {
        var basicLadderPositions = floorPositions;
        foreach(var position in basicLadderPositions)
        {
            if (Random.Range(0, 1500) < 1)
            {
                tileMapVisualizer.PaintSingleBasicLadder(position);
            }
        }

    }
}
