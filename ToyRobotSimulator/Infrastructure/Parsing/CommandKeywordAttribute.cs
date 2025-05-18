using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Infrastructure.Parsing
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandKeywordAttribute : Attribute
    {
        public string Keyword { get; }
        public bool HasArguments { get; }

        public CommandKeywordAttribute(string keyword, bool hasArguments = false)
        {
            Keyword = keyword;
            HasArguments = hasArguments;
        }
    }
}
