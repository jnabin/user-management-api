using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand { }
    public interface ICommand<TResposne> : IRequest<Result<TResposne>>, IBaseCommand { }
    public interface IBaseCommand { }
}
