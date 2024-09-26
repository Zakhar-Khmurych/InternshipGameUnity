using UnityEngine;
using UnityEngine.UI; // Додаємо для роботи з Canvas
using Model;

namespace Assets.Controller
{
    public class CellObject : MonoBehaviour
    {
        public Sprite blackCellSprite, whiteCellSprite;
        
    }
    
    public class GridManager : MonoBehaviour
    {
        public GameObject cellPrefab; // Префаб для клітинки (UI Image)
        public RectTransform gridParent; // Canvas або панель для розміщення клітинок
        public int gridWidth = 10; // Ширина поля
        public int gridHeight = 10; // Висота поля
        public float cellSize = 40.0f; // Розмір клітинки в пікселях (40x40)

        private Cell[,] gridCells; // Логічна модель клітинок
        private CellView[,] cellViews; // Масив візуальних клітинок (CellView)

        // Спрайти для клітинок
        private Sprite blackCellSprite;
        private Sprite whiteCellSprite;

        void Start()
        {
            // Завантажуємо спрайти для клітинок
            blackCellSprite = Resources.Load<Sprite>("Sprites/cell_B");
            whiteCellSprite = Resources.Load<Sprite>("Sprites/cell_W");

            GenerateGrid();
            Debug.Log("Grid created successfully");
        }

        // Метод для генерації сітки клітинок
        void GenerateGrid()
        {
            gridCells = new Cell[gridWidth, gridHeight];
            cellViews = new CellView[gridWidth, gridHeight]; // Масив для візуальних представлень клітинок
    
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // Створюємо об'єкт клітинки на Canvas
                    GameObject cellObject = Instantiate(cellPrefab, gridParent);
                    cellObject.name = $"Cell_{x}_{y}";

                    // Налаштовуємо розмір і позицію клітинки через RectTransform
                    RectTransform rectTransform = cellObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = new Vector2(cellSize, cellSize);
                    rectTransform.anchoredPosition = new Vector2(x * cellSize, y * cellSize);

                    // Вибираємо спрайт для клітинки в залежності від позиції
                    Image cellImage = cellObject.GetComponent<Image>();
                    Sprite cellSprite = (x + y) % 2 == 0 ? whiteCellSprite : blackCellSprite;
                    cellImage.sprite = cellSprite;

                    // Додаємо до клітинки логіку для вибору та підсвітки
                    CellView cellView = cellObject.GetComponent<CellView>();
                    gridCells[x, y] = new Cell(); // Прив'язуємо модель клітинки
                    cellView.SetModel(gridCells[x, y]);

                    // Зберігаємо посилання на CellView для майбутньої взаємодії
                    cellViews[x, y] = cellView;
                }
            }
        }

        // Підсвітка клітинки
        public void HighlightCell(int x, int y, UnityEngine.Color highlightColor)
        {
            CellView cellView = cellViews[x, y];
            cellView.Highlight(highlightColor);
        }

        // Скидання підсвітки клітинки
        public void ResetHighlightCell(int x, int y)
        {
            CellView cellView = cellViews[x, y];
            cellView.ResetHighlight();
        }
    }
}
