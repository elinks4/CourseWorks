using System;

namespace GameWebApi
{
    public class NewPlayer
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public int Level { get; set; }

        public int Score { get; set; }

        public bool IsBanned { get; set; }

        public DateTime CreationTime { get; set; }

        

        
    }
}