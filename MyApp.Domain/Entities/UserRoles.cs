using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class UserRoles
    {
        public Guid UserRoleId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        protected UserRoles() { } // For EF Core

        public ICollection<Users> Users { get; private set; } = new List<Users>();

        public UserRoles(string name, string description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public void DeleteUserRole()
        {
            IsActive = false;
        }

        public void ReactivateUserRole()
        {
            IsActive = true;
        }
    }
}
