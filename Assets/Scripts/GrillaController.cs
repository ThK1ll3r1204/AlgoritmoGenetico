using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GrillaController : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject iceBlockPrefab;
    //[SerializeField] GameObject MudBlockPrefab;
    [SerializeField] GameObject emptyBlockPrefab;
    public int gridSize = 10;
    public float delay = 0.5f;
    
    [SerializeField]
    int[][,] arrayGridMatrix;

    void Start()
    {


        int[,] matrix1 ={
        { 1,1,1,1,1,1,1,1,1,1},
        { 1,1,0,0,0,0,0,0,0,1},
        { 1,0,2,2,2,2,2,2,0,1},
        { 1,0,2,0,0,0,0,2,0,1},
        { 1,0,2,0,0,1,1,2,0,1},
        { 1,0,2,0,1,1,0,2,0,1},
        { 1,0,2,0,1,0,0,2,0,1},
        { 1,0,2,2,1,2,2,2,0,1},
        { 1,0,0,0,1,0,0,0,0,1},
        { 1,1,1,1,1,1,1,1,1,1} };

        int[,] matrix2 =
            {{1,1,1,1,0,1,1,1,2,2},
            {1,1,1,1,0,1,0,0,2,2},
            {1,1,1,1,0,1,0,0,0,1},
            {1,1,1,1,1,1,0,0,1,1},
            {1,1,1,0,1,1,0,0,1,1},
            {0,0,0,0,1,1,0,0,1,1},
            {2,2,1,1,1,1,0,2,2,2},
            {2,2,0,0,0,0,0,2,2,2},
            {2,2,0,0,0,0,0,2,2,2},
            {2,2,1,1,1,1,1,2,2,2}};

        int[,] matrix3 =
            {{1,1,1,0,0,0,0,0,0,0},
            {1,1,1,0,0,0,0,0,2,2},
            {1,1,1,1,1,1,1,1,2,2},
            {0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,1},
            {1,1,1,2,2,2,2,1,1,1},
            {1,0,0,0,0,0,0,0,0,0},
            {2,2,2,0,0,0,0,0,0,0},
            {2,2,2,0,0,0,0,0,0,0},
            {2,2,2,1,1,1,1,1,1,1}};

        int[,] matrix4 =
            {{1,1,1,0,0,0,0,2,2,2},
            {1,1,1,0,0,0,0,2,0,2},
            {1,1,1,0,0,0,0,2,0,2},
            {2,2,2,2,2,0,0,2,0,2},
            {2,2,2,2,2,0,0,2,2,2},
            {2,2,2,2,2,0,0,2,2,0},
            {0,0,0,1,1,0,0,1,1,0},
            {0,0,0,1,1,0,0,1,1,0},
            {0,0,0,2,2,2,2,2,2,0},
            {0,0,0,2,2,2,2,2,2,0}};

        int[,] matrix5 =
            {{1,1,1,1,1,0,0,0,0,0},
            {1,1,1,1,1,0,0,0,0,0},
            {1,1,1,1,1,0,0,0,2,2},
            {0,0,0,0,1,0,0,0,2,2},
            {0,0,0,0,1,0,0,0,2,2},
            {0,0,0,0,1,0,0,0,2,2},
            {0,0,0,0,1,1,1,1,2,2},
            {2,2,2,2,2,1,1,1,2,2},
            {2,0,0,0,2,0,0,0,0,0},
            {2,2,2,2,2,0,0,0,0,0}};

        int[,] matrix6 =
            { {1,1,1,1,1,1,1,1,1,1},
            { 1,1,1,0,0,0,0,0,0,0},
            { 1,1,1,1,0,0,0,0,1,0},
            { 1,0,0,1,1,0,0,2,2,2},
            { 1,1,0,0,1,1,1,2,2,2},
            { 1,1,0,0,0,0,0,0,0,1},
            { 1,1,0,0,0,0,0,0,0,1},
            { 1,0,0,0,0,0,1,0,2,2},
            { 2,2,2,0,0,1,1,0,2,2},
            { 2,2,2,1,1,1,1,1,1,0} };

        int[,] matrix7 =
            { {1,1,1,1,1,1,1,1,1,1},
            { 1,1,0,0,0,0,0,0,0,1},
            { 1,0,0,0,2,2,2,0,0,1},
            { 1,0,0,2,2,2,2,2,0,1},
            { 1,0,2,2,0,0,2,2,1,1},
            { 1,0,2,2,0,0,2,2,1,0},
            { 1,0,2,2,2,2,2,2,0,0},
            { 1,0,0,2,2,2,2,2,0,0},
            { 1,0,0,0,0,2,2,2,0,0},
            { 1,1,1,1,1,1,1,1,1,0} };

        int[,] matrix8 =
            { {1,1,0,0,1,1,0,1,0,0},
            { 1,1,0,0,1,0,0,1,0,0},
            { 1,0,0,0,0,0,1,1,0,0},
            { 0,0,0,0,1,1,1,1,1,0},
            { 1,1,0,1,1,1,1,2,2,2},
            { 0,0,0,1,1,0,1,2,2,2},
            { 0,1,1,1,0,0,0,2,2,2},
            { 2,2,0,0,0,2,2,2,2,2},
            { 2,2,0,0,0,2,2,2,2,0},
            { 0,1,1,1,1,1,1,1,0,0}};

        int[,] matrix9 =
            { {1,1,0,1,2,2,1,0,0,0},
            { 1,1,1,1,2,2,1,1,0,0},
            { 0,1,1,1,2,2,1,1,1,0},
            { 1,1,1,0,1,1,0,1,1,1},
            { 0,1,1,0,1,1,0,1,1,0},
            { 0,2,2,2,2,2,2,2,2,0},
            { 2,2,0,2,2,2,2,0,2,2},
            { 0,2,2,0,0,0,0,2,2,0},
            { 0,0,2,2,2,2,2,2,0,0},
            { 0,0,0,2,2,2,2,0,0,0} };

        int[,] matrix10 =
            { {1,1,1,1,1,1,1,1,1,0},
            { 1,1,1,0,0,0,1,1,1,0},
            { 1,1,0,0,1,2,2,2,1,0},
            { 1,1,0,0,1,2,2,2,1,0},
            { 1,0,0,0,1,2,0,0,1,0},
            { 1,0,2,2,1,0,0,0,1,0},
            { 2,2,2,2,1,0,0,1,1,0},
            { 2,2,0,0,0,0,1,1,1,0},
            { 2,2,1,1,1,1,1,1,0,0},
            { 0,0,0,0,0,0,0,0,0,0}};

        int[,] matrix11 =
            { {1,1,1,0,0,0,0,2,2,0},
            { 1,1,1,1,1,1,1,2,2,1},
            { 1,1,1,1,0,1,1,2,2,1},
            { 1,0,0,1,0,1,0,0,0,1},
            { 2,2,2,1,1,1,1,0,0,1},
            { 2,2,2,0,1,0,1,0,0,1},
            { 0,0,0,0,1,0,1,0,0,1},
            { 2,2,2,0,1,2,2,0,2,2},
            { 2,2,2,1,1,2,2,0,2,2},
            { 0,2,2,1,0,0,1,1,2,2} };

        int[,] matrix12 =
            { {1,1,0,0,0,0,0,0,1,1},
            { 1,1,1,0,0,1,0,1,1,1},
            { 0,1,1,1,1,1,1,1,0,0},
            { 0,0,1,2,2,2,2,2,2,0},
            { 0,0,1,2,1,1,2,2,2,0},
            { 0,1,1,2,1,1,2,2,2,0},
            { 0,0,1,2,2,2,2,2,2,0},
            { 0,1,1,2,2,2,2,2,2,0},
            { 2,2,0,2,2,2,2,2,2,0},
            { 2,2,0,0,0,0,0,0,0,0} };

        int[,] matrix13 =
            { {1,1,1,1,1,1,1,0,0,0},
            { 1,1,1,2,2,1,1,2,0,0},
            { 1,1,2,1,2,0,1,1,2,0},
            { 1,2,1,2,0,2,2,1,1,1},
            { 1,1,0,2,0,0,0,2,2,1},
            { 1,2,2,0,0,0,2,0,1,1},
            { 1,1,1,2,2,0,2,1,1,1},
            { 0,2,1,1,0,2,1,1,1,1},
            { 0,0,2,1,1,2,1,1,1,0},
            { 0,0,0,1,1,1,1,1,0,0} };

        int[,] matrix14 =
            { {1,1,0,1,1,2,2,2,2,0},
            { 1,1,0,1,1,2,2,2,2,1},
            { 1,0,0,2,2,0,0,1,1,1},
            { 1,0,1,2,2,0,0,0,1,1},
            { 1,0,0,2,2,0,0,1,1,1},
            { 1,0,0,2,2,0,0,0,0,0},
            { 1,0,0,0,2,0,1,1,0,0},
            { 1,0,0,0,2,0,1,1,0,1},
            { 1,2,2,1,1,0,0,1,1,1},
            { 0,2,2,0,0,0,1,1,1,0} };

        int[,] matrix15 =
            { {1,1,1,1,1,1,1,1,0,0},
            { 1,1,0,1,0,0,2,2,2,0},
            { 1,0,0,1,0,0,0,2,2,1},
            { 1,1,1,2,2,2,2,0,2,1},
            { 1,0,0,2,2,0,2,0,0,1},
            { 1,0,0,2,0,2,2,0,0,1},
            { 1,2,0,2,2,2,2,1,2,1},
            { 1,2,2,0,0,0,1,0,2,1},
            { 0,2,2,2,0,0,2,2,1,0},
            { 0,0,1,1,1,1,1,1,0,0} };

        arrayGridMatrix = new int[][,] { matrix1, matrix2, matrix3, matrix4, matrix5, matrix6, matrix7, matrix8, matrix9, matrix10, matrix11, matrix12, matrix13, matrix14, matrix15};
        int randomIndex = Random.Range(0, arrayGridMatrix.Length);
        StartCoroutine(SpawnCubes(arrayGridMatrix[randomIndex]));
        

    }

    IEnumerator SpawnCubes(int[,] gridMatrix)
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                int blockType = gridMatrix[y, x];
                Vector3 spawnPosition = new Vector3(x, 0, y); 

                if (blockType == 1)
                {
                    Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 2)
                {
                    Instantiate(iceBlockPrefab, spawnPosition, Quaternion.identity);
                }
                else if (blockType == 3)
                {
                    Instantiate(emptyBlockPrefab, spawnPosition, Quaternion.identity);
                }

                yield return new WaitForSeconds(delay);
            }
        }
    }
}



