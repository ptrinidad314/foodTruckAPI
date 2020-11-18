using System;
using System.Collections.Generic;

namespace foodTruckAPI.Data.Models
{
    public partial class FilmActor
    {
        public short ActorId { get; set; }
        public short FilmId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
