using System;
using Microsoft.AspNetCore.Identity;


namespace TichuSensei.Core.Domain.Entities
{
    public class Player
    {
        public string PlayerId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string AvatarPath { get; set; }
        public virtual PlayerStats Stats { get; set; }        
    }

}
