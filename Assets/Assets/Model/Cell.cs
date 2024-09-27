namespace Model
{
    public class Cell
    {
        // public bool IsTaken { get; set; }
        public Creature CellTaker { get; set; }

        public Cell()
        {
            CellTaker = null;
        }

        public void RemoveCreature()
        {
            CellTaker = null;
        }

        public void PutCreature(Creature creature)
        {
            CellTaker = creature;
        }

        public void MoveAway(Cell targetCell)
        {
            targetCell.CellTaker = this.CellTaker;
            this.CellTaker = null;
        }

        public bool IsEmpty()
        {
            if (CellTaker == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}