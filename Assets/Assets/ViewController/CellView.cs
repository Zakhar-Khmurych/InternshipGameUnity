using UnityEngine;
using UnityEngine.UI; // Для роботи з UI-компонентами
using Model;

namespace Assets.Controller
{
    public class CellView : MonoBehaviour
    {
        private Cell cellModel; // Модель клітинки
        public Image cellImage; // Image для клітинки (UI)

        // Метод для прив'язки моделі клітинки
        public void SetModel(Cell model)
        {
            cellModel = model;
            UpdateView();
        }

        // Оновлення візуальної частини клітинки
        public void UpdateView()
        {
            if (cellModel.IsEmpty())
            {
                // Якщо клітинка порожня, можна залишити базовий спрайт
            }
            else
            {
                // Якщо в клітинці є істота, оновлюємо спрайт відповідно
            }
        }

        // Метод для підсвітки клітинки
        public void Highlight(Color color)
        {
            cellImage.color = color; // Використовуємо UnityEngine.Color
        }

        public void ResetHighlight()
        {
            cellImage.color = Color.white; // Використовуємо UnityEngine.Color.white
        }
    }
}