using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    public class EnemyFactory
    {
        private Dictionary<string, Enemy> _enemies = new Dictionary<string, Enemy>(); 
        public EnemyFactory()
        {
            _enemies.Add("aerialenemy", new AerialEnemy());
            _enemies.Add("divebombenemy", new DivebombEnemy());
            _enemies.Add("marksmanenemy", new MarksmanEnemy()); 
        }

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
