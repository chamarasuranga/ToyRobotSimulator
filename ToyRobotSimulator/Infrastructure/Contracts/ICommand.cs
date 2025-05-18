using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Infrastructure.Contracts
{
    public interface ICommand : IRequest<Unit> { }
}
