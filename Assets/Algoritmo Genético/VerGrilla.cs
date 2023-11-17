using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerGrilla : MonoBehaviour
{
    
        public GameObject cubePrefab;  // Prefab para el bloque 1
        public GameObject iceBlockPrefab;  // Prefab para el bloque 2
        public GameObject emptyBlockPrefab;  // Prefab para el bloque 3
        public float delay = 0.1f;  // Retraso entre la aparición de bloques

        private int gridSize = 10;  // Tamaño de la cuadrícula

        public void MostrarCuadricula(int[,] gridMatrix)
        {
            StartCoroutine(SpawnCubes(gridMatrix));
        }

        IEnumerator SpawnCubes(int[,] gridMatrix)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    int blockType = gridMatrix[y, x];
                    Vector3 spawnPosition = new Vector3(x, 0, y);

                    if (blockType == (int)TipoBloque.Bloque1)
                    {
                        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    }
                    else if (blockType == (int)TipoBloque.Bloque2)
                    {
                        Instantiate(iceBlockPrefab, spawnPosition, Quaternion.identity);
                    }
                    else if (blockType == (int)TipoBloque.Bloque3)
                    {
                        Instantiate(emptyBlockPrefab, spawnPosition, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    }

                    yield return new WaitForSeconds(delay);
                }
            }
        }
    
}
