using NSpec;
using UniformRenamer;
using UniformRenamer.Core;

namespace UniformRenamerTests
{
    class file_name_spec : nspec
    {
        void spec_GetExtension()
        {
            it["normal file name"] = () => new FileName(@"sandbox\fixtures\test.zip").GetExtension().should_be(".zip");
            it["file name with two extensions"] = () => new FileName(@"sandbox\fixtures\test.jpg.zip").GetExtension().should_be(".zip");
            it["folder without dot in name"] = () => new FileName(@"sandbox\fixtures\folder").GetExtension().should_be(""); //folder path must have a \ at the end
            it["folder with dot in name"] = () => new FileName(@"sandbox\fixtures\folder.vm1").GetExtension().should_be("");
            it["file in folder"] = () => new FileName(@"sandbox\fixtures\folder.vm1\test.zip").GetExtension().should_be(".zip");
                        
        }

        void spec_GetRenamableNamePart()
        {
            it["file"] = () => new FileName(@"sandbox\fixtures\folder.vm1\test.zip").GetRenamableNamePart().should_be("test");
            it["folder"] = () => new FileName(@"sandbox\fixtures\folder.vm1").GetRenamableNamePart().should_be("folder.vm1");
        }

        void spec_IsDirectory()
        {
            it["file"] = () => new FileName(@"sandbox\fixtures\folder.vm1\test.zip").IsDirectory().should_be_false();
            it["folder with dot in name"] = () => new FileName(@"sandbox\fixtures\folder.vm1").IsDirectory().should_be_true();
            it["folder"] = () => new FileName(@"sandbox\fixtures\folder").IsDirectory().should_be_true();
        }

        void spec_ToString()
        {
            it["folder"] = () => new FileName(@"sandbox\fixtures\folder").ToString().should_be("folder");
            it["file"] = () => new FileName(@"sandbox\fixtures\folder.vm1\test.zip").ToString().should_be("test.zip");
        }

        void spec_MakeValidFileName()
        {
            it["folder"] = () => FileName.MakeValidFileName("folder").should_be("folder");
            it["folder"] = () => FileName.MakeValidFileName("folder!@#$%^&*").should_be("folder!@#$%^& ");
            it["folder"] = () => FileName.MakeValidFileName("()").should_be("()");
        }
    }
}
