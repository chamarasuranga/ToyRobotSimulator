﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Infrastructure.Contracts;
using ToyRobotSimulator.Infrastructure.Parsing;

namespace ToyRobotSimulator.Commands
{
    [CommandKeyword("REPORT")]
    public class ReportCommand : ICommand { }
}
