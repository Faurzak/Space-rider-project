using System;
using UnityEngine;

public class ParticulaScript : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}
