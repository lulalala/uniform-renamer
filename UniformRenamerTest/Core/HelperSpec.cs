using NSpec;
using UniformRenamer;
using UniformRenamer.Core;

namespace UniformRenamerTests
{
    class helper_spec : nspec
    {
        void spec_CleanRuleText()
        {
            it["strip comments"] = () => Helper.CleanRuleText("abc //comments").should_be("abc\r\n");
            it["strip comments multi-line"] = () =>
            {
                string str = "a\nb//comments\nc";
                Helper.CleanRuleText(str).should_be("a\r\nb\r\nc\r\n");
            };
        }
    }
}
