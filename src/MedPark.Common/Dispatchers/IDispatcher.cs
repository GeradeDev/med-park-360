using MedPark.Common.Messages;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
