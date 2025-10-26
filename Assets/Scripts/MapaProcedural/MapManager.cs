using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool Spawneable;
    }

    private CellData[,] BoardData;
    private Tilemap TileMapGround;
    private Tilemap TileMapBorder;

    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] BorderTiles;
    
    [Header("Spawning")]
    [Tooltip("Meta. Para ir al siguiente nivel final")]
    public GameObject MetaPrefab;
    [Tooltip("Pickup.")]
    public GameObject PickupPrefab;
    
    [Min(0)] public int MetaCount = 1;
    [Min(0)] public int PickupCount = 10;

    [Tooltip("Optional: Margen donde no esta permitido spawnear objetos.")]
    [Min(0)] public int SpawnMarginFromBorder = 1;
    
    [Tooltip("Semilla para poder reproducir escenarios de prueba. 0 = Random")]
    public int RandomSeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (RandomSeed != 0) Random.InitState(RandomSeed);
        
        TileMapGround = GetComponentsInChildren<Tilemap>(true)
            .FirstOrDefault(tm => tm.name == "Ground");
        TileMapBorder = GetComponentsInChildren<Tilemap>(true)
            .FirstOrDefault(tm => tm.name == "CantWalk");

        GenerateBoard();
        SpawnThings();
    }

    void GenerateBoard()
    {
        BoardData = new CellData[Width, Height];

        for (int y = 0; y < Height; ++y)
        {
            for(int x = 0; x < Width; ++x)
            {
                BoardData[x,y] = new CellData();
                
                bool IsBorder = x == 0 || y == 0 || x == Width - 1 || y == Height - 1;
                Tile BorderTile = null;
              
                if(IsBorder)
                {
                    BorderTile = BorderTiles[Random.Range(0, BorderTiles.Length)];
                    BoardData[x,y].Spawneable = false;
                }
                else
                {
                    BoardData[x,y].Spawneable = true;
                }

                Tile GroundTile = GroundTiles[Random.Range(0, GroundTiles.Length)];
                TileMapGround.SetTile(new Vector3Int(x, y, 0), GroundTile);
                if (BorderTile != null) TileMapBorder.SetTile(new Vector3Int(x, y, 0), BorderTile);
            }
        }
    }
    
    void SpawnThings()
    {
        var Candidates = new List<Vector2Int>();
        int MinX = Mathf.Clamp(SpawnMarginFromBorder, 1, Width - 2);
        int MaxX = Mathf.Clamp(Width - 1 - SpawnMarginFromBorder, 1, Width - 2);
        int MinY = Mathf.Clamp(SpawnMarginFromBorder, 1, Height - 2);
        int MaxY = Mathf.Clamp(Height - 1 - SpawnMarginFromBorder, 1, Height - 2);

        for (int y = MinY; y <= MaxY; ++y)
        {
            for (int x = MinX; x <= MaxX; ++x)
            {
                if (BoardData[x, y].Spawneable)
                    Candidates.Add(new Vector2Int(x, y));
            }
        }
        
        Shuffle(Candidates);

        int MetaToSpawn = Mathf.Clamp(MetaCount, 0, Candidates.Count);
        int PickupToSpawn = Mathf.Clamp(PickupCount, 0, Mathf.Max(0, Candidates.Count - MetaToSpawn));

        // Spawn Meta(s)
        for (int i = 0; i < MetaToSpawn; ++i)
        {
            if (MetaPrefab == null) break;
            var cell = Candidates[0];
            Candidates.RemoveAt(0);
            InstantiateAtCell(MetaPrefab, cell);
        }

        // Spawn Pickups
        for (int i = 0; i < PickupToSpawn; ++i)
        {
            if (PickupPrefab == null) break;
            var cell = Candidates[0];
            Candidates.RemoveAt(0);
            InstantiateAtCell(PickupPrefab, cell);
        }
    }

    void InstantiateAtCell(GameObject prefab, Vector2Int cell)
    {
        Vector3Int cell3 = new Vector3Int(cell.x, cell.y, 0);
        Vector3 worldPos = TileMapGround.CellToWorld(cell3) + TileMapGround.cellSize * 0.5f;
        worldPos.z = 0f;

        Instantiate(prefab, worldPos, Quaternion.identity, transform);
    }
    
    static void Shuffle<T>(IList<T> list)
    {
        for (int i = 0; i < list.Count - 1; ++i)
        {
            int j = Random.Range(i, list.Count);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

}