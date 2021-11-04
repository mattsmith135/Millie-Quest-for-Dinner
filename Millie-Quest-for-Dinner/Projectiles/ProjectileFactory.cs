using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner.Projectiles
{
    /// <summary>
    /// Implements the factory method. Creates projectile objects without exposing the 
    /// instantiation logic to the client. 
    /// </summary>
    public class ProjectileFactory
    {
        private Dictionary<string, Projectile> _projectiles = new Dictionary<string, Projectile>(); 

        public ProjectileFactory()
        {
            // populating dictionary
            _projectiles = new Dictionary<string, Projectile>(); 
            _projectiles.Add("poop", new Poop());
            _projectiles.Add("laser", new Laser()); 
        }

        /// <summary>
        /// Creates a projectile based on the projectileName string passed into the function. 
        /// It creates the projectile using the _projectiles dictionary
        /// </summary>
        /// <param name="projectileName">Name of projectile you want to create</param>
        /// <returns>Projectile corresponding to key passed in</returns>
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
