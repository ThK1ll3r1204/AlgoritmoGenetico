using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmoGenetico : MonoBehaviour
{
    private Poblacion poblacion;
    private VerGrilla visualizadorCuadricula;
    private int numeroGeneraciones = 100; // N�mero fijo de generaciones (ajusta seg�n sea necesario)

    void Start()
    {
        poblacion = new Poblacion();
        visualizadorCuadricula = GetComponent<VerGrilla>();

        // Ejecutar el algoritmo gen�tico
        EjecutarAlgoritmoGenetico();
    }

    void EjecutarAlgoritmoGenetico()
    {
        for (int generacion = 0; generacion < numeroGeneraciones; generacion++)
        {
            // Generar nueva poblaci�n
            List<Individuo> nuevaGeneracion = new List<Individuo>();

            for (int i = 0; i < poblacion.ObtenerTamanoPoblacion(); i += 2)
            {
                // Seleccionar padres
                Individuo padre = poblacion.SeleccionarPorTorneo();
                Individuo madre = poblacion.SeleccionarPorTorneo();

                // Cruzar padres para crear hijos
                Individuo hijo1 = poblacion.Cruzar(padre, madre);
                Individuo hijo2 = poblacion.Cruzar(padre, madre);

                // Mutar hijos
                hijo1.Mutar();
                hijo2.Mutar();

                // Agregar hijos a la nueva generaci�n
                nuevaGeneracion.Add(hijo1);
                nuevaGeneracion.Add(hijo2);
            }

            // Reemplazar la poblaci�n anterior con la nueva generaci�n
            poblacion.ReemplazarPoblacion(nuevaGeneracion);
        }

        // Mostrar resultados finales o realizar otras acciones al finalizar el algoritmo
        MostrarResultadosFinales();
    }

    void MostrarResultadosFinales()
    {
        // Obtener el individuo con mejor aptitud de la poblaci�n
        Individuo mejorIndividuo = ObtenerMejorIndividuo();

        // Obtener la cuadr�cula del mejor individuo
        int[,] mejorCuadricula = mejorIndividuo.ConvertirCromosomaATipoInt();

        // Mostrar la cuadr�cula visualmente
        visualizadorCuadricula.MostrarCuadricula(mejorCuadricula);
    }

    Individuo ObtenerMejorIndividuo()
    {
        Individuo mejorIndividuo = poblacion.ObtenerPoblacion()[0]; // Inicializar con el primer individuo

        foreach (Individuo individuo in poblacion.ObtenerPoblacion())
        {
            if (individuo.CalcularAptitud() > mejorIndividuo.CalcularAptitud())
            {
                mejorIndividuo = individuo;
            }
        }

        return mejorIndividuo;
    }
}
