namespace Model
{
    public class Session
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Grid SessionGrid { get; set; }

        public Session(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;

            // Ініціалізуємо сітку в SessionManager
        }

        public void PlaceNecromancers()
        {
            // Створюємо Некромантів
            var necromancer1 = new Necromancer();
            var necromancer2 = new Necromancer();

            // Додаємо Некромантів до активних істот гравців
            Player1.ActiveCreaturesByID.Add(necromancer1.ID);
            Player2.ActiveCreaturesByID.Add(necromancer2.ID);

            Player1.NecromancerID = necromancer1.ID;
            Player2.NecromancerID = necromancer2.ID;

            // Розміщуємо Некромантів у кутах сітки
            SessionGrid.PlaceCreature(0, 0, necromancer1); // Верхній лівий кут
            SessionGrid.PlaceCreature(SessionGrid.Width - 1, SessionGrid.Height - 1, necromancer2); // Нижній правий кут
        }
    }
}