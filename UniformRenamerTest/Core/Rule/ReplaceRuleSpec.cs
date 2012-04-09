using NSpec;
using UniformRenamer;
using UniformRenamer.Core;

namespace UniformRenamerTests
{
    class replace_rule_spec : nspec
    {
        void spec_Apply()
        {
            context["normal text"] = () =>
            {
                ReplaceRule rule = new ReplaceRule("<target>", "new text", new string[] { "test" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("new text<target>");
            };

            context["regular expression"] = () =>
            {
                ReplaceRule rule = new ReplaceRule("<target>", "new text", new string[] { "* t.st" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("new text<target>");
            };

            context["regular expression with capturing"] = () =>
            {
                ReplaceRule rule = new ReplaceRule("<target>", "new text", new string[] { "* (te.t)" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("new text<target>");
            };

            context["regular expression with capturing excluding text"] = () =>
            {
                ReplaceRule rule = new ReplaceRule("<target>", "new text", new string[] { "* (te)st" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("new text<target>");
            };
        }
    }
}