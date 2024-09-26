using Model;
using UnityEngine;

namespace Assets.Controller
{
    public class CreatureFactory
    {
        public GameObject CreateCreature(Creature creature)
        {
            GameObject creatureObject = new GameObject(creature.GetType().Name);
            
            SpriteRenderer renderer = creatureObject.AddComponent<SpriteRenderer>();

            CreatureBehaviour creatureBehaviour = creatureObject.AddComponent<CreatureBehaviour>();
            creatureBehaviour.SetCreature(creature);

            
            
            // Можемо налаштувати спрайт залежно від типу істоти
            // //це ШІ писав
            if (creature is Necromancer)
            {
                renderer.sprite = Resources.Load<Sprite>("Assets/Assets/Sprites/necromancer.png");
            }
            else if (creature is Skeleton)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Skeleton");
            }
            else if (creature is Knight)
            {
                renderer.sprite = Resources.Load<Sprite>("Assets/Assets/Sprites/knight.png");
            }
            else if (creature is Berserker)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Berserker");
            }
            else if (creature is Assassin)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Assassin");
            }
            else if (creature is Elf)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Elf");
            }
            else if (creature is Goblin)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Goblin");
            }
            else if (creature is Wall)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Wall");
            }
            
            creatureObject.transform.position = Vector3.zero;

            return creatureObject;
        }
        
        
    }
}