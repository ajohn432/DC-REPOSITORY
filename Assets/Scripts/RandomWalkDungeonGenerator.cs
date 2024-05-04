using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// This class generates a randomwalkdungeon generator
/// 
/// the idea of this algorithm is you basically have the algo start at 0,0,
/// and walk randomly in 1 of the 4 cardinal directions for a number of iterations.
/// 
/// You then do this many times in a row, either continuing from the last spot or from 0,0
/// depending on how convoluted and spread out you want the dungeon.
/// 
/// Increasing iterations massively increases size, while increasing walk times greatly increases
/// the concentration of tiles. I made a few seperate dungeon parameter templates inside of unity.
/// </summary>
public class RandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;
    /// <summary>
    /// RunProceduralGeneration overrides the abstract class method runproceduralgeneration,
    /// which creates a really easy format to implement new algorithms, or even combine them like we did.
    /// 
    /// All this method really does is take in the serialized parameters, executes the runrandom walk method below,
    /// then runs the wallgenerator to add walls.
    /// </summary>
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tileMapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
    }
    /// <summary>
    /// RunRandomWalk actually operates the random walk method. It takes in the parameters and start position,
    /// which can vary based on the parameters. 
    /// 
    /// IMPORTANTLY, uses hashset to track floorpositions, as there is no reason not to only keep 1 copy of all used
    /// floor tiles. If 2 iterations end up with the same tiles, (which they do a lot), it does not create duplicates.
    /// It adds each iterations by unioning with var path. It also allows like stated earlier depending on if startrandomlyeach iteration is selected in unity,
    /// to have either a random or previous start.
    /// 
    /// Most importantly, it calls ProceduralGenerationAlgorithms.SimpleRandomWalk, which is where the actual algorithm is.
    /// 
    /// </summary>
    /// <param name="randomWalkParameters"></param>
    /// <param name="position"></param>
    /// <returns></returns>

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO randomWalkParameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }
}
