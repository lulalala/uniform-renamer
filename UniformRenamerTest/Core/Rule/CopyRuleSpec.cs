using NSpec;
using UniformRenamer;
using UniformRenamer.Core;

namespace UniformRenamerTests
{
    class copy_rule_spec : nspec
    {
        void spec_Apply()
        {
            context["normal text"] = () =>
            {
                CopyRule rule = new CopyRule("<target>", new string[] { "test" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("test<target>");
            };

            context["regular expression"] = () =>
            {
                CopyRule rule = new CopyRule("<target>", new string[] { "* test" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("test<target>");
            };

            context["regular expression with capturing"] = () =>
            {
                CopyRule rule = new CopyRule("<target>", new string[] { "* (test)" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("test<target>");
            };

            context["regular expression with capturing excluding text"] = () =>
            {
                CopyRule rule = new CopyRule("<target>", new string[] { "* (te)st" });
                string oldName = "first test 1";
                string newFormat = "<target>";
                rule.Apply(ref oldName, ref newFormat);
                it["remove text from old name"] = () => oldName.should_be("first  1");
                it["copy text to new format"] = () => newFormat.should_be("te<target>");
            };
        }
    }
}