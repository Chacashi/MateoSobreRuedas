using System.Collections.Generic;
using UnityEngine;

public static class CarCleaner
{
    private static List<GameObject> autosActivos = new List<GameObject>();

    public static void RegistrarAuto(GameObject auto)
    {
        autosActivos.Add(auto);
    }

    public static void DestruirAutos()
    {
        foreach (var auto in autosActivos)
        {
            if (auto != null)
                GameObject.Destroy(auto);
        }

        autosActivos.Clear();
    }
}
