using UnityEngine;
using System.Collections;

public class MultipleIntExample : MonoBehaviour {
    public interface IThing
    {
        string ThingName { get; set; }
    }

    interface IDamage
    {
        int HitPoints { get; set; }
        void TakeDamage(int damage);
        void HealDamage(int damage);
    }

    class Zombie : MonoBehaviour, IThing, IDamage {
        private string ZombieName;
        private int ZombieHitPoints;

        public int HitPoints
        {
            get
            {
                return ZombieHitPoints;
            }

            set
            {
                ZombieHitPoints = value;
            }
        }

        public void TakeDamage (int damage)
        {
            ZombieHitPoints -= damage;
        }

        public void HealDamage(int damage)
        {
            return;
        }

        public string ThingName
        {
            get
            {
                return ZombieName;
            }

            set
            {
                ZombieName = value;
            }
        }

        public void SayHallo()
        {
            print("brains");
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
