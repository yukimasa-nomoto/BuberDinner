﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds= new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public HostId  HostId { get;  }

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get;}

        private Menu(MenuId id , string name , string description, HostId hostId
            , List<MenuSection>? sections
            , DateTime createdDateTime , DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            if (sections != null) _sections = sections;
        }

        //public static Menu Create(string name, string description , HostId hostId)
        //{
        //    return new Menu(MenuId.CreateUnique(), name, description , hostId
        //        ,DateTime.UtcNow , DateTime.UtcNow);
        //}

        public static Menu Create(HostId hostId, string name, string description , List<MenuSection>? sections = null)
        {
            return new Menu(MenuId.CreateUnique(), name, description, hostId
                ,sections
                , DateTime.UtcNow, DateTime.UtcNow);
        }


    }
}
