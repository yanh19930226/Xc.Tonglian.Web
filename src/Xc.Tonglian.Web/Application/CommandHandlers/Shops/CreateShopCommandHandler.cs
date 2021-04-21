using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Application.Commands.Shops;

namespace Xc.Tonglian.Web.Application.CommandHandlers.Shops
{
    public class CreateShopCommandHandler : INotificationHandler<CreateShopCommand>
    {
        public Task Handle(CreateShopCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
