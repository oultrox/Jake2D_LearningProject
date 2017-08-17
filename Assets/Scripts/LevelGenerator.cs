using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public static LevelGenerator instance;
    [SerializeField] private List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    [SerializeField] private Transform levelStartPoint;
    [SerializeField] private List<LevelPiece> pieces = new List<LevelPiece>();

    private void Awake()
    {
        //Singleton creation
        if (instance == null)
        {
            instance = this;
        }else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GenerateInitialPieces();
    }


    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        //Pick the random number
        int randomIndex = Random.Range(0, levelPrefabs.Count);

        //instantiate copy of random level prefab and store it in piece variable.
        LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //position
        if (pieces.Count == 0)
        {
            //first piece
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //take the exit point from last piece as a spawn point to the new piece.
            spawnPosition = pieces[pieces.Count - 1].ExitPoint.position;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

    public void RestartPieces()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            LevelPiece oldestPiece = pieces[i];
            Destroy(oldestPiece.gameObject);
        }
        pieces.Clear();
        GenerateInitialPieces();

    }
}
