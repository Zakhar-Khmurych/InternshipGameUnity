namespace Assets.Controller
{
    using UnityEngine;
    using Model;

    public class CreatureBehaviour : MonoBehaviour
    {
        private Creature creature;

        public void SetCreature(Creature creature)
        {
            this.creature = creature;
        }

        void Update()
        {
            
        }
    }

}