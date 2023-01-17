using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menu = Menu.Create(HostId.Create(request.HostId), request.Name, request.Description
                , request.Sections.Select(s => MenuSection.Create(
                    s.Name
                    , s.Description
                    , s.Items.Select(item => MenuItem.Create(
                        item.Name
                        ,item.Description
                        )).ToList()
                    )).ToList()
                );

            //Persisit Menu
            _menuRepository.Add(menu);

            //Return Menu

            return menu;
        }
    }
}
