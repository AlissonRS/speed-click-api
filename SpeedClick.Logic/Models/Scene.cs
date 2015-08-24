using Alisson.Core;
using Alisson.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedClick.Logic.Models
{
    public class Scene: BaseObject
    {

        public float HP { get; set; } // How fast the HP decreases...
        public string Instructions { get; set; }
        public int SceneLength { get; set; } // In secs...
        public string Title { get; set; }
        public int TurnLength { get; set; } // In secs...
        public int Turns { get; set; } // How much turns the player has to play before we change the source images...
        public int CreatorID { get; set; }
        public bool UseCustomTargetImages { get; set; }
        public int SourceImageCount { get; set; }
        public int TargetImageCount { get; set; }
        public int PlayCount { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Score> GetScores()
        {
            return BaseRepository<Score>.getAll(s => s.SceneId == this.ID);
        }

    }
}
