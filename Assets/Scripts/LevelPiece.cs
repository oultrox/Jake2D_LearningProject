using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPiece : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;

    public Transform ExitPoint
    {
        get
        {
            return exitPoint;
        }

        set
        {
            exitPoint = value;
        }
    }
}
