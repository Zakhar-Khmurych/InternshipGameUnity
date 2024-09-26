using System;

namespace Model
{
    public struct StaticStats
{
    public int HP;
    public int Movement;
    public int Defence;
    public int Attack;
    public int Damage;
    public int DamageDiceSize;
    public int InitiativeModifier;
    public int Cost;
}

public struct DynamicStats
{
    public int CurrentHP;
    public int MovementRemaining;
    public bool StillCanAttack;
    public int Initiative;
    public int RelativeInitiative;
}



public abstract class Creature
{
    //technical stats
    public long ID;
    //hardcodded gameplay stats
    public int HP;
    public int Movement;
    public int Defence;
    public int Attack;
    public int Damage;
    public int DamageDiceSize;
    public int IntitativeModifier;
    public int Cost;
    //dynamic stats
    public int CurrentHP { get; set; }
    public int MovementRemaining;
    public bool StillCanAttack;
    public int Initiative;
    public int RelativeInitiative;

    public Creature()
    {
        ID = GenerateID();
        CurrentHP = HP;
    }
    

    private long GenerateID()
    {
        // Отримуємо поточний час
        DateTime now = DateTime.Now;

        // Формуємо ID на основі дати та часу з точністю до мілісекунд
        long id = now.Month * 10000000000 + 
                 now.Day * 100000000 + 
                 now.Hour * 1000000 + 
                 now.Minute * 10000 + 
                 now.Second * 100 + 
                 now.Millisecond;

        return id;
    }
    
    public void Punch(Creature target)
    {
        int attack_value = Attack + new Dice(20).Roll(); //влучання, фіксоване влучання + к20
        if (attack_value > target.Defence) //якшо влучили, дамажимо
        {
            target.CurrentHP -= (Damage + new Dice(DamageDiceSize).Roll()); //шкода, фіксована + куб
            
        }
    }
    public void RollInitiative()
    {
        Initiative = IntitativeModifier + new Dice( 20).Roll();
    }
    public int ResolveInitiative()
    {
        RelativeInitiative = new Dice(100).Roll();
        return RelativeInitiative;
    }
}
}

