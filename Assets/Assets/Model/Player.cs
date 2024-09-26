using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Player
{
    public string Name { get; set; }
    public int Coins { get; set; }  
    
    public int FibCost { get; set; }

    public List<long> ActiveCreaturesByID;
    public long NecromancerID;


    
    public Player(string name)
    {
        Name = name;
        Coins = 0;
        FibCost = 0;

        // Ініціалізуємо список активних істот
        ActiveCreaturesByID = new List<long>();
    }

    public void GiveCoin(int reward)
    {
        Coins += reward;
    }

    public int FibonacciCost()
    {
        int[] fibonacciSequence = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 };
        int creatureCount = ActiveCreaturesByID.Count;

        if (creatureCount == 0)
        {
            return fibonacciSequence[0]; // Якщо немає істот, беремо перше число
        }
        else if (creatureCount >= fibonacciSequence.Length)
        {
            return fibonacciSequence[fibonacciSequence.Length - 1]; // Якщо істот більше, ніж довжина масиву, беремо останнє число
        }
        else
        {
            return fibonacciSequence[creatureCount];
        }
    }

    public void SummonCreature<T>(Grid grid) where T : Creature, new()
    {
        // Знаходимо Некроманта серед активних істот
        var necromancer = ActiveCreaturesByID.FirstOrDefault(c => c is Necromancer);

        // Якщо Некроманта немає або немає достатньо монет, нічого не робимо
        if (necromancer == null || Coins < FibonacciCost()) return;

        // Знаходимо сусідню вільну клітинку
        var freeCell = grid.AttackReach(NecromancerID).FirstOrDefault(c => c.IsEmpty());

        // Якщо є вільна клітинка, створюємо істоту
        if (freeCell != null)
        {
            T creature = new T();

            // Стягуємо вартість істоти
            Coins -= creature.Cost * FibonacciCost();

            // Додаємо істоту до списку активних
            ActiveCreaturesByID.Add(creature.ID);

            // Знаходимо координати клітинки
            var coordinates = grid.FindCellCoordinates(freeCell);
            if (coordinates.HasValue)
            {
                var (x, y) = coordinates.Value;
                // Розміщуємо істоту на полі за знайденими координатами
                Console.WriteLine($"{creature.GetType()} spawned by {Name}");
                grid.PlaceCreature(x, y, creature);
            }
        }

    }

    public void SpawnCreature(Grid grid)
    {
        Console.WriteLine("press key to spawn a creature");
        Console.WriteLine("1: skeleton, 2: knight, 3: berserker, 4: elf, 5: goblin,  6: assassin");
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.D1:
                SummonCreature<Skeleton>(grid);
                break;
            case ConsoleKey.D2:
                SummonCreature<Knight>(grid);
                break;
            case ConsoleKey.D3:
                SummonCreature<Berserker>(grid);
                break;
            case ConsoleKey.D4:
                SummonCreature<Elf>(grid);
                break;
            case ConsoleKey.D5:
                SummonCreature<Goblin>(grid);
                break;
            case ConsoleKey.D6:
                SummonCreature<Assassin>(grid);
                break;
        }
    }

}
}