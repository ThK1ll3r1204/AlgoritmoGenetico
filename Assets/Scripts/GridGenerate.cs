using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridGenerate : MonoBehaviour
{
    /*[Header("Corrutina")]
    [SerializeField] float delay;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject iceBlock;
    [SerializeField] GameObject emptyBlock;

    [Header("MATRICES")]
    public int[,] forma1 = {{1, 1, 1, 1}};

    public int[,] forma2 = {{1, 1, 1},
                            {1, 1, 1}};

    public int[,] forma3 = {{1, 1},
                            {1, 1}};

    public int[,] forma4 = {{1, 1, 1},
                            {1, 1, 1}};

    public int[,] forma5 = { { 1 }};
    
    public int[,] forma6 = { { 1 },
                             { 1 } };

    public int[,] forma7 = { { 1 },
                             { 1 },
                             { 1 }};

    public int[,] forma8 = { { 1, 1, 1 } };

    public int[,] forma9 = { { 1, 1 } };
    
        void Start()
    {
        List<int[,]> formasTetris = new List<int[,]>
        {
            forma1 , forma2 , forma3 , forma4 , forma5 , forma6 , forma7, forma8, forma9                     
        };
        int[,] matrizGenerada = GeneradorMatriz.GenerarMatriz(formasTetris,10,10);
        StartCoroutine(SpawnCubes(matrizGenerada));
    }

    void Update()
    {
        
    }

    IEnumerator SpawnCubes(int[,] gridMatrix)
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                int blockType = gridMatrix[y, x];
                Vector3 spawnPosition = new Vector3(x, 0, y);

                if (blockType == 1)
                {
                    Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 2)
                {
                    Instantiate(iceBlock, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 3)
                {
                    Instantiate(emptyBlock, spawnPosition, Quaternion.identity);
                }

                yield return new WaitForSeconds(delay);
            }
        }
               
    }*/
    [Header("Corrutina")]
    [SerializeField] float delay;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject iceBlock;
    [SerializeField] GameObject emptyBlock;

    [Header("MATRICES")]
    public int[,] forma1 = { { 1, 1, 1, 1 } };

    public int[,] forma2 = {{1, 1, 1},
                            {1, 1, 1}};

    public int[,] forma3 = {{1, 1},
                            {1, 1}};

    public int[,] forma4 = {{1, 1, 1},
                            {1, 1, 1}};

    public int[,] forma5 = { { 1 } };

    public int[,] forma6 = { { 1 },
                             { 1 } };

    public int[,] forma7 = { { 1 },
                             { 1 },
                             { 1 }};

    public int[,] forma8 = { { 1, 1, 1 } };

    public int[,] forma9 = { { 1, 1 } };

    public int[,] forma10 = { { 1, 1, 1 },
                              { 1, 0, 0 } };

    public int[,] forma11 = { { 1, 1, 0 },
                              { 0, 1, 1 } };

    public int[,] forma12 = { { 1, 1, 1, 1, 1 } };

    public int[,] forma13 = { { 1, 1, 1 },
                              { 0, 0, 1 } };

    public int[,] forma14 = { { 1, 0, 0 },
                              { 1, 1, 1 } };

    public int[,] forma15 = { { 1, 1, 1 },
                              { 1, 0, 0 } };

    void Start()
    {
        List<int[,]> formasTetris = new List<int[,]>
        {
            forma1, forma2, forma3, forma4, forma5,
            forma6, forma7, forma8, forma9, forma10,
            forma11, forma12, forma13, forma14, forma15
        };
        int[,] matrizGenerada = GeneradorMatriz.GenerarMatriz(formasTetris, 10, 10);
        StartCoroutine(SpawnCubes(matrizGenerada));
    }

    void Update()
    {

    }

    IEnumerator SpawnCubes(int[,] gridMatrix)
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                int blockType = gridMatrix[y, x];
                Vector3 spawnPosition = new Vector3(x, 0, y);

                if (blockType == 1)
                {
                    Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 2)
                {
                    Instantiate(iceBlock, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 3)
                {
                    Instantiate(emptyBlock, spawnPosition, Quaternion.identity);
                }

                yield return new WaitForSeconds(delay);
            }
        }
    }
}
