using UnityEngine;
using UnityEngine.UI; // Додаємо для роботи з Canvas
using Model;

namespace Assets.Controller
{
    public class GridManager : MonoBehaviour
    {
        public GameObject cell; // Префаб для клітинки
        public int gridWidth = 2; // Ширина поля
        public int gridHeight = 2; // Висота поля
        public float cellSize = 40.0f; // Розмір клітинки в пікселях (100x100)
        
        void Start()
        {
            GenerateGrid();
        }

        // Метод для генерації сітки клітинок
        void GenerateGrid()
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // Створюємо об'єкт клітинки на сцені
                    GameObject cellObject = Instantiate(cell, transform);

                    // Розміщуємо об'єкт відповідно до координат
                    RectTransform rectTransform = cellObject.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(x * cellSize, -y * cellSize); // Відступи по X та Y

                    // Перефарбовуємо непарні клітинки у синій колір
                    if ((x + y) % 2 != 0)
                    {
                        cellObject.GetComponent<Image>().color = Color.blue; // Міняємо колір на синій
                    }
                }
            }
        }
        
    }
}
