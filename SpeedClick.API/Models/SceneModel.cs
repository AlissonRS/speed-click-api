using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedClick.API.Models
{
    public class SceneModel
    {
        public int ID;
        public string Instructions;
        public string Title;
        public int SceneLength; // In secs...
        public int TurnLength; // In secs...
        public int Turns; // How much turns the player has to play before we change the source images...
        public int SourceImageCount;
        public int TargetImageCount;
        public float HP; // How fast the HP decreases...
        public bool UseCustomTargetImages;
        public int PlayCount;
        public UserModelResponse Creator;
        public IEnumerable<ScoreModel> Scores { get; set; }
    }
}
