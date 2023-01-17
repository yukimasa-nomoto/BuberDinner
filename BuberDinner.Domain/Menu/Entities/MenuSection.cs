using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();


        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId id , string name , string description , List<MenuItem>? items) : base(id)
        {
            Name= name;
            Description= description;
            if(items != null) _items = items;
        }

        public static MenuSection Create(string name, string description, List<MenuItem>? items = null)
        {
            return new MenuSection(MenuSectionId.CreateUnique(), name, description , items);
        }



    }
}
