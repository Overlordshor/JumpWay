﻿using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject Cube;
    public GameObject CubesParent;

    private void Start()
    {
        var cube = Instantiate(Cube, new Vector3(4f, -4.08f, 5f), Quaternion.Euler(new Vector3(0, 60, 0)));
        cube.transform.parent = CubesParent.transform;
    }
}