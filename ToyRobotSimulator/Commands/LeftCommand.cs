using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Infrastructure.Contracts;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ToyRobotSimulator.Infrastructure.Parsing;

namespace ToyRobotSimulator.Commands


{
    [CommandKeyword("LEFT")]
    public class LeftCommand : ICommand { }





}
