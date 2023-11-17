using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individuo
{
    private int gridSize = 10;

    private TipoBloque[,] cromosoma;

    public Individuo()
    {
        cromosoma = GenerarCromosomaAleatorio();
    }

    private TipoBloque[,] GenerarCromosomaAleatorio()
    {
        TipoBloque[,] cromosomaAleatorio = new TipoBloque[gridSize, gridSize];
        System.Random rand = new System.Random();

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                cromosomaAleatorio[i, j] = (TipoBloque)rand.Next(5); 
            }
        }

        return cromosomaAleatorio;
    }

    public TipoBloque[,] ObtenerCromosoma()
    {
        return cromosoma;
    }

    public int[,] ConvertirCromosomaATipoInt()
    {
        int[,] cromosomaInt = new int[gridSize, gridSize];

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                cromosomaInt[y, x] = (int)cromosoma[y, x];
            }
        }

        return cromosomaInt;
    }

    public int CalcularAptitud()
    {
        int aptitud = 0;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cromosoma[i, j] != TipoBloque.Vacio)
                {
                    aptitud++;
                }
            }
        }

        return aptitud;
    }

    private float probabilidadMutacion = 0.1f;

    public void Mutar()
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (rand.NextDouble() < probabilidadMutacion)
                {
                    cromosoma[i, j] = (TipoBloque)rand.Next(5); // 0 a 4
                }
            }
        }
    }

}

public enum TipoBloque
{
    Vacio = 0,
    Bloque1 = 1,   
    Bloque2 = 2,
    Bloque3 = 3,
    Bloque4 = 4,
    Bloque5 = 5,
    Bloque6 = 6,
    Bloque7 = 7,
    Bloque8 = 8,
    Bloque9 = 9,
    Bloque10 = 10,
}
