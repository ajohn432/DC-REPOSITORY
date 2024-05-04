using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
/// <summary>
/// The tilemapvisualizer operates the actual painting of all of the tiles, ladder, wall, and floor alike.\
/// It does this through abstracting and taking in serialized fields, which are basicially fields specified in the unity client,
/// which takes in the tiles it will be coloring in. There are only 3 of these, which makes it extremely simple.
/// 
/// These are floortilemap, walltilemap, and laddertilemap
/// </summary>
public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap, ladderTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop, ladder;
    /// <summary>
    /// This method takes in the floorpositions calculated in one of the 2 algorithms I made,
    /// then adds it to the 2 serialized fields, which are tilemap and tilebase.
    /// 
    /// A tilemap is a map of all tiles that have the same properties.
    /// 
    /// A floortile is the actual tile texture that will be painted.
    /// </summary>
    /// <param name="floorPositions"></param>
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }
    /// <summary>
    /// This method then iterates through all of the given positions using a for loop, and executes this for each individual location.
    /// </summary>
    /// <param name="positions"></param>
    /// <param name="tilemap"></param>
    /// <param name="tile"></param>
    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    /// <summary>
    /// Paint single tile is called in painttiles, and it basically takes in a single tile on the grid and paints it.
    /// </summary>
    /// <param name="tilemap"></param>
    /// <param name="tile"></param>
    /// <param name="position"></param>
    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
    /// <summary>
    /// This is a basic method used between map generations to clear all tiles on the floor.
    /// Unfortunately, we were not able to figure out how to actually execute this to make multiple levels, but 
    /// using generate dungeon in the unity client it works fine.
    /// </summary>
    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        ladderTileMap.ClearAllTiles();
    }
    /// <summary>
    /// This method is the same as the Paintsingletile method, but it is executed in the wallgenerator method
    /// </summary>
    /// <param name="position"></param>
    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
    /// <summary>
    /// This method is the same as the Paintsingletile method, but it is executed in the laddergenerator method
    /// </summary>
    /// <param name="position"></param>
    internal void PaintSingleBasicLadder(Vector2Int position)
    {
        PaintSingleTile(ladderTileMap, ladder, position);
    }
}
