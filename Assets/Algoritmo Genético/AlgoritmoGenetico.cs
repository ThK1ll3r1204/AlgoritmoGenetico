using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmoGenetico : MonoBehaviour
{
    private Poblacion poblacion;
    private VerGrilla visualizadorCuadricula;
    private int numeroGeneraciones = 100; // Número fijo de generaciones (ajusta según sea necesario)

    void Start()
    {
        poblacion = new Poblacion();
        visualizadorCuadricula = GetComponent<VerGrilla>();

        // Ejecutar el algoritmo genético
        EjecutarAlgoritmoGenetico();
    }

    void EjecutarAlgoritmoGenetico()
    {
        for (int generacion = 0; generacion < numeroGeneraciones; generacion++)
        {
            // Generar nueva población
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

                // Agregar hijos a la nueva generación
                nuevaGeneracion.Add(hijo1);
                nuevaGeneracion.Add(hijo2);
            }

            // Reemplazar la población anterior con la nueva generación
            poblacion.ReemplazarPoblacion(nuevaGeneracion);
        }

        // Mostrar resultados finales o realizar otras acciones al finalizar el algoritmo
        MostrarResultadosFinales();
    }

    void MostrarResultadosFinales()
    {
        // Obtener el individuo con mejor aptitud de la población
        Individuo mejorIndividuo = ObtenerMejorIndividuo();

        // Obtener la cuadrícula del mejor individuo
        int[,] mejorCuadricula = mejorIndividuo.ConvertirCromosomaATipoInt();

        // Mostrar la cuadrícula visualmente
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
