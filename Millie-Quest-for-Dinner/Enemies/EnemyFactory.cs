using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Implements the factory method. Creates enemy objects without exposing the 
    /// instantiation logic to the client. 
    /// </summary>
    public class EnemyFactory
    {
        private Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>(); // dictionary containing string keys and enemy values
        public EnemyFactory()
        {
            // populating dictionary
            _enemies.Add("aerialenemy", new AerialEnemy());
            _enemies.Add("divebombenemy", new DivebombEnemy());
            _enemies.Add("marksmanenemy", new MarksmanEnemy()); 
        }

        /// <summary>
        /// Creates an enemy based on the enemyName string passed into the function. 
        /// It creates the enemy using the _enemies dictionary
        /// </summary>
        /// <param name="enemyName">Name of enemy you want to create</param>
        /// <returns>Enemy corresponding to key passed in</returns>
        public Enemy createEnemy(string enemyName)
        {
            enemyName = enemyName.ToLower();

            Enemy enemy = _enemies[enemyName]; 
            
            if (enemy == null)
            {
                return null; 
            } else
            {
                return enemy; 
            }
        }
    }
}
