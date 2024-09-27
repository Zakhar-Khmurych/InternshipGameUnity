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
    public int gridWidth = 5;       // Ширина сітки
    public int gridHeight = 5;      // Висота сітки
    private float cellSize = 80.0f; // Розмір клітинки (80x80 пікселів)
    private GameObject firstCell;   // Посилання на першу клітинку

    void Start()
    {
        // Знайдемо першу клітинку (її можна знайти за ім'ям або тегом)
        firstCell = GameObject.Find("Cell_0_0");

        if (firstCell != null)
        {
            Debug.Log("Перша клітинка знайдена.");
        }
        else
        {
            Debug.Log("Перша клітинка не знайдена, створюємо нову.");
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
        }

        // Генерація сітки
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Перевіряємо, чи це перша клітинка, щоб не створювати її знову
                if (x == 0 && y == 0)
                    continue;

                // Розраховуємо позицію нової клітинки
                Vector3 position = new Vector3(x * cellSize, y * cellSize, 0);
                
                // Створюємо нову клітинку
                GameObject newCell = Instantiate(objectPrefab, position, Quaternion.identity);
                newCell.name = $"Cell_{x}_{y}";

                // Якщо клітинка непарна, фарбуємо її у синій
                if ((x + y) % 2 != 0)
                {
                    newCell.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
        }
    }
}










