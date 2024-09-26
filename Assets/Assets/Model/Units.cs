namespace Model
{
    public class Necromancer : Creature
    {
        public Necromancer() : base()
        {
            HP = 10;
            Movement = 6;
            Defence = 14;
            Attack = 4;
            Damage = 2;
            DamageDiceSize = 6;
            IntitativeModifier = 2;
            Cost = 1;
        }
    }

    public class Skeleton : Creature
    {
        public Skeleton( ) : base()
        {
            HP = 4;
            Movement = 4;
            Defence = 8;
            Attack = 0;
            Damage = 0;
            DamageDiceSize = 6;
            IntitativeModifier = 0;
            Cost = 0;
        }
    }

    public class Knight : Creature
    {
        public Knight() : base()
        {
            HP = 12;
            Movement = 4;
            Defence = 16;
            Attack = 6;
            Damage = 3;
            DamageDiceSize = 8;
            IntitativeModifier = 0;
            Cost = 1;
        }
    }

    public class Berserker : Creature
    {
        public Berserker() : base()
        {
            HP = 16;
            Movement = 6;
            Defence = 12;
            Attack = 7;
            Damage = 4;
            DamageDiceSize = 12;
            IntitativeModifier = 2;
            Cost = 1;
        }
    }

    public class Assassin : Creature
    {
        public Assassin() : base()
        {
            HP = 8;
            Movement = 6;
            Defence = 8;
            Attack = 2;
            Damage = 2;
            DamageDiceSize = 24;
            IntitativeModifier = 4;
            Cost = 1;
        }
    }

    public class Elf : Creature
    {
        public Elf() : base()
        {
            HP = 8;
            Movement = 8;
            Defence = 12;
            Attack = 4;
            Damage = 2;
            DamageDiceSize = 8;
            IntitativeModifier = 4;
            Cost = 1;
        }
    }

    public class Goblin : Creature
    {
        public Goblin() : base()
        {
            HP = 4;
            Movement = 6;
            Defence = 12;
            Attack = 3;
            Damage = 1;
            DamageDiceSize = 4;
            IntitativeModifier = 8;
            Cost = 1;
        }
    }

    public class Wall : Creature
    {
        public Wall() : base()
        {
            HP = 1;
            Movement = 0;
            Defence = 40;
            Attack = 0;
            Damage = 0;
            DamageDiceSize = 1;
            IntitativeModifier = 0;
            Cost = 0;
        }
    }
}