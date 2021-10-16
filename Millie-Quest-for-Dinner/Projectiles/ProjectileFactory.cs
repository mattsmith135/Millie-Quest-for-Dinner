using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner.Projectiles
{
    public class ProjectileFactory
    {
        private Dictionary<string, Projectile> _projectiles = new Dictionary<string, Projectile>(); 

        public ProjectileFactory()
        {
            _projectiles = new Dictionary<string, Projectile>(); 
            _projectiles.Add("poop", new Poop());
            _projectiles.Add("laser", new Laser()); 
        }

        public Projectile createProjectile(string projectileName)
        {
            projectileName = projectileName.ToLower();

            Projectile projectile = _projectiles[projectileName]; 

            if (projectile == null)
            {
                return null; 
            } else
            {
                return projectile; 
            }
        }
    }
}
