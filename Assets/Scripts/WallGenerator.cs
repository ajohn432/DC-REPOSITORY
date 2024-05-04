using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Wall generator class
/// 
/// This class operates the abstraction of finding every need wall position on the map.
/// When a dungeon is generated in the higher level classes (Corridorfirstdungeongenerator and proceduraldungeongenerationalgorithm),
/// this program is executed and given all of the tiles. It then iterates through all of them and finds all cardinal directions and 
/// checks them to see if they are included in the floorpositions. It does this using the findwallsindirections method
/// 
/// It then iterates through all of the provided wall tiles and places walls in all of them.
/// </summary>
public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tileMapVisualizer.PaintSingleBasicWall(position);
        }
    }
/// <summary>
/// This method takes in floorpositions, and directions, and checks each tile to see if a tile is present in the floorpositions hashtable
/// It then adds it to the wall hashtable if it is not present
/// </summary>
/// <param name="floorPositions"></param>
/// <param name="directionList"></param>
/// <returns></returns>
    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach(var position in floorPositions)
        {
            foreach(var direction in directionList)
            {
                var neighborPosition = position+direction;
                if (floorPositions.Contains(neighborPosition) == false)
                {
                    wallPositions.Add(neighborPosition);
                }
            }
        }
        return wallPositions;
    }
}
