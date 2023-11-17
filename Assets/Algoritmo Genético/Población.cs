using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poblacion
{
    private List<Individuo> individuos;
    private int gridSize = 10;

    private int tamanoPoblacion = 10; 

    public Poblacion()
    {
        individuos = new List<Individuo>();

        for (int i = 0; i < tamanoPoblacion; i++)
        {
            Individuo nuevoIndividuo = new Individuo();
            individuos.Add(nuevoIndividuo);
        }
    }

    public List<Individuo> ObtenerPoblacion()
    {
        return individuos;
    }

    public Individuo SeleccionarPorTorneo()
    {
        int indice1 = Random.Range(0, tamanoPoblacion);
        int indice2 = Random.Range(0, tamanoPoblacion);

        if (individuos[indice1].CalcularAptitud() > individuos[indice2].CalcularAptitud())
        {
            return individuos[indice1];
        }
        else
        {
            return individuos[indice2];
        }
    }

    public int ObtenerTamanoPoblacion()
    {
        return tamanoPoblacion;
    }

    public Individuo Cruzar(Individuo padre, Individuo madre)
    {
        Individuo hijo = new Individuo();

        int puntoDeCruce = Random.Range(1, gridSize * gridSize - 1);

        for (int i = 0; i < puntoDeCruce; i++)
        {
            int fila = i / gridSize;
            int columna = i % gridSize;
            hijo.ObtenerCromosoma()[fila, columna] = padre.ObtenerCromosoma()[fila, columna];
        }

        for (int i = puntoDeCruce; i < gridSize * gridSize; i++)
        {
            int fila = i / gridSize;
            int columna = i % gridSize;
            hijo.ObtenerCromosoma()[fila, columna] = madre.ObtenerCromosoma()[fila, columna];
        }

        return hijo;
    }

    public void ReemplazarPoblacion(List<Individuo> nuevaGeneracion)
    {
        individuos = nuevaGeneracion;
    }

}
