using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string filePath = "data.json";

    public Data data = new Data();

    public TextMeshProUGUI cantidadTexto;

    public void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados");
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(json);
            Debug.Log("Datos cargados: " + data.cantidad);
            UpdateCantidadText();
        }
        else
        {
            Debug.Log("No se encontró el archivo");
        }
    }

    public void Sumar()
    {
        data.cantidad++;
        UpdateCantidadText();
    }

    public void prueba()
    {
        Debug.Log("Prueba");    
    }

    public void Resta()
    {
        data.cantidad--;
        UpdateCantidadText(); 
    }

    private void UpdateCantidadText()
    {
        if (cantidadTexto != null)
        {
            cantidadTexto.text = "" + data.cantidad;
        }
    }
}
[System.Serializable]
public class Data
{
    public int cantidad;
}
