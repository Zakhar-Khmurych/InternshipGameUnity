using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Controller;
using Model;
using UnityEngine;


// /https://www.youtube.com/watch?v=GfZeLJfk3RQ
public class _Controller_GodObject : MonoBehaviour
{
    public GameObject objectPrefab; // Префаб об'єкта для інстанціювання
    public int gridSize = 10;       // Ширина сітки
    private GameObject firstCell;   // Посилання на першу клітинку

    void Start()
    {
        // Завантажуємо префаб і створюємо першу клітинку, якщо її не знайдено
        objectPrefab = Resources.Load<GameObject>("Objects/cellPrefab");
        if (objectPrefab != null)
        {
            Vector3 position = new Vector3(0, 0, 0); // Початкова позиція
            firstCell = Instantiate(objectPrefab, position, Quaternion.identity);
            firstCell.name = "Cell_0_0";
        }
        else
        {
            Debug.LogError("Префаб не знайдено. Перевір назву та шлях.");
            return;
        }

        // Генерація сітки
        GenerateGrid(gridSize);
    }

    void GenerateGrid(int gridSize)
    {
        Vector3 gridOffset = new Vector3(-5, -5, 0); // Зсув сітки
        Vector3 cellScale = new Vector3(2.4f, 2.4f, 1);
        
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x, y, 0) + gridOffset; // Додаємо зсув

                // Instantiate the new cell
                GameObject newCell = Instantiate(objectPrefab, position, Quaternion.identity);
                newCell.name = $"Cell_{x}_{y}";
                newCell.transform.localScale = cellScale;
                if ((x + y) % 2 != 0)
                {
                    newCell.GetComponent<SpriteRenderer>().color = Color.gray;
                }
            }
        }
    }


    
    
}










