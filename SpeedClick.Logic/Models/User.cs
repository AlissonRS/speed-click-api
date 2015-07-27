using Alisson.Core;
using Alisson.Core.Encryption;
using Alisson.Core.Repository;
using Alisson.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SpeedClick.Logic.Models
{
    public class User : BaseObject
    {

        public string Login { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }
        public int Status { get; set; }


        public User() : base() { }

        public User(int id) : base(id) { }

        public IEnumerable<Scene> getScenes()
        {
            return BaseRepository<Scene>.getAll(s => s.Creator == this.ID);
        }

        public override ObjectTypes getObjectType()
        {
            return ObjectTypes.User;
        }

    }

}
