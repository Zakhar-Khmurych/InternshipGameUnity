using System.Collections.Generic;

namespace Model
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return Cells[x, y];
        }

        public void PlaceCreature(int x, int y, Creature creature)
        {
            Cell cell = GetCell(x, y);
            if (cell.IsEmpty())
            {
                cell.CellTaker = creature;
            }
        }

        public void RemoveCreature(int x, int y)
        {
            Cell cell = GetCell(x, y);
            cell.CellTaker = null;
        }

        public List<Cell> DijkstraXY(int startX, int startY, int steps)
        {
            var reachableCells = new List<Cell>();
            var distances = new int[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    distances[x, y] = int.MaxValue;
                }
            }

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((startX, startY));
            distances[startX, startY] = 0;

            int[] dx = {0, 1, 0, -1}; // можливі зміщення за X (вправо, вниз, вліво, вгору)
            int[] dy = {-1, 0, 1, 0}; // можливі зміщення за Y (вгору, вправо, вниз, вліво)

            while (queue.Count > 0)
            {
                var (currentX, currentY) = queue.Dequeue();
                int currentDistance = distances[currentX, currentY];

                for (int i = 0; i < 4; i++)
                {
                    int nextX = currentX + dx[i];
                    int nextY = currentY + dy[i];

                    if (IsValidPosition(nextX, nextY) && distances[nextX, nextY] == int.MaxValue &&
                        Cells[nextX, nextY].IsEmpty())
                    {
                        int newDistance = currentDistance + 1;
                        if (newDistance <= steps)
                        {
                            distances[nextX, nextY] = newDistance;
                            queue.Enqueue((nextX, nextY));
                            reachableCells.Add(Cells[nextX, nextY]);
                        }
                    }
                }
            }

            return reachableCells;
        }

        // Метод для перевірки, чи є позиція в межах сітки
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public List<Cell> DijkstraCell(Cell startCell, int steps)
        {
            var reachableCells = new List<Cell>();
            var distances = new int[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    distances[x, y] = int.MaxValue;
                }
            }

            // Знаходимо координати стартової клітинки
            int startX = -1, startY = -1;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y] == startCell)
                    {
                        startX = x;
                        startY = y;
                        break;
                    }
                }

                if (startX != -1) break;
            }

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((startX, startY));
            distances[startX, startY] = 0;

            int[] dx = {0, 1, 0, -1}; // зміщення за X (вправо, вниз, вліво, вгору)
            int[] dy = {-1, 0, 1, 0}; // зміщення за Y (вгору, вправо, вниз, вліво)

            while (queue.Count > 0)
            {
                var (currentX, currentY) = queue.Dequeue();
                int currentDistance = distances[currentX, currentY];

                for (int i = 0; i < 4; i++)
                {
                    int nextX = currentX + dx[i];
                    int nextY = currentY + dy[i];

                    if (IsValidPosition(nextX, nextY) && distances[nextX, nextY] == int.MaxValue &&
                        Cells[nextX, nextY].IsEmpty())
                    {
                        int newDistance = currentDistance + 1;
                        if (newDistance <= steps)
                        {
                            distances[nextX, nextY] = newDistance;
                            queue.Enqueue((nextX, nextY));
                            reachableCells.Add(Cells[nextX, nextY]);
                        }
                    }
                }
            }

            return reachableCells;
        }

        public List<Cell> GetReachableCellsByCreatureId(long creatureId, int steps)
        {
            // Знаходимо клітинку, де розміщена істота з вказаним ID
            Cell startCell = null;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].CellTaker?.ID == creatureId)
                    {
                        startCell = Cells[x, y];
                        break;
                    }
                }

                if (startCell != null) break;
            }

            // Якщо істоти з таким ID немає, повертаємо null
            if (startCell == null) return null;

            // Використовуємо попередній метод, передаючи знайдену клітинку
            return DijkstraCell(startCell, steps);
        }

        public List<Cell> AttackReach(long creatureId)
        {
            // Знаходимо клітинку, де розміщена істота з вказаним ID
            Cell startCell = null;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].CellTaker?.ID == creatureId)
                    {
                        startCell = Cells[x, y];
                        break;
                    }
                }

                if (startCell != null) break;
            }

            // Якщо істоти з таким ID немає, повертаємо null
            if (startCell == null) return null;

            var neighboringCells = new List<Cell>();
            int startX = -1, startY = -1;

            // Знаходимо координати стартової клітинки
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y] == startCell)
                    {
                        startX = x;
                        startY = y;
                        break;
                    }
                }

                if (startX != -1) break;
            }

            // Масиви для зміщення в усіх 8-ми напрямках (включаючи діагональні)
            int[] dx = {-1, 0, 1, 1, 1, 0, -1, -1};
            int[] dy = {-1, -1, -1, 0, 1, 1, 1, 0};

            for (int i = 0; i < 8; i++)
            {
                int nextX = startX + dx[i];
                int nextY = startY + dy[i];

                if (IsValidPosition(nextX, nextY))
                {
                    neighboringCells.Add(Cells[nextX, nextY]);
                }
            }

            return neighboringCells;
        }

        public void RemoveCreatureById(long creatureId)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].CellTaker?.ID == creatureId)
                    {
                        Cells[x, y].CellTaker = null;
                        break;
                    }
                }
            }
        }

        public List<long> BringOutYourDead()
        {
            List<long> deadCreaturesIds = new List<long>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cell cell = Cells[x, y];
                    if (cell.CellTaker != null && cell.CellTaker.CurrentHP < 1)
                    {
                        deadCreaturesIds.Add(cell.CellTaker.ID);
                        cell.RemoveCreature();
                    }
                }
            }

            return deadCreaturesIds;
        }

        public List<Creature> GetCreaturesByIds(List<long> ids)
        {
            List<Creature> foundCreatures = new List<Creature>();

            foreach (var cell in Cells)
            {
                if (cell.CellTaker != null && ids.Contains(cell.CellTaker.ID))
                {
                    foundCreatures.Add(cell.CellTaker);
                }
            }

            return foundCreatures;
        }

        public List<Creature> GetAllCreatures()
        {
            List<Creature> foundCreatures = new List<Creature>();

            foreach (var cell in Cells)
            {
                if (cell.CellTaker != null)
                {
                    foundCreatures.Add(cell.CellTaker);
                }
            }

            return foundCreatures;
        }

        public void UpdateInitiativeOnGridLevel()
        {
            foreach (var cell in Cells)
            {
                if (cell.CellTaker != null)
                {
                    cell.CellTaker.RollInitiative();
                }
            }
        }

        public (int x, int y)? FindCellCoordinates(Cell cell)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y] == cell)
                    {
                        return (x, y);
                    }
                }
            }

            return null; // якщо клітинку не знайдено
        }

    }
}