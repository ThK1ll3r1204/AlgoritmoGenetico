using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneradorMatriz : MonoBehaviour
{
    public static int[,] GenerarMatriz(List<int[,]> formas, int matrizAncho, int matrizAlto)
    {
        int[,] matrizPrincipal = new int[matrizAlto, matrizAncho];
        System.Random rand = new System.Random();

        // Barajamos las formas para variar la disposición
        Shuffle(formas, rand);

        foreach (var forma in formas)
        {
            int i, j;

            do
            {
                i = rand.Next(matrizAlto - forma.GetLength(0) + 1);
                j = rand.Next(matrizAncho - forma.GetLength(1) + 1);
            } while (!FormaEncaja(matrizPrincipal, forma, i, j));

            // Coloca la forma en la matriz
            for (int x = 0; x < forma.GetLength(0); x++)
            {
                for (int y = 0; y < forma.GetLength(1); y++)
                {
                    matrizPrincipal[i + x, j + y] = forma[x, y];
                }
            }
        }

        return matrizPrincipal;
    }

    private static bool FormaEncaja(int[,] matriz, int[,] forma, int posX, int posY)
    {
        for (int x = 0; x < forma.GetLength(0); x++)
        {
            for (int y = 0; y < forma.GetLength(1); y++)
            {
                if (forma[x, y] == 1 && matriz[posX + x, posY + y] == 1)
                {
                    // Conflicto con otra forma ya colocada
                    return false;
                }
            }
        }

        return true;
    }

    private static void Shuffle<T>(List<T> list, System.Random rand)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
