using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniformRenamer.Core
{
    public static class Constants
    {
        //TODO enum
        //public const int RuleDelete = 0;
        //public const int RuleCopy = 1;
        //public const int RuleReplace = 2;

        //
    }
}

public enum RuleType: int
{
    RuleDelete = 0,
    RuleCopy = 1,
    RuleReplace =2
}