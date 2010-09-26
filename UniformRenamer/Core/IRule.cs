namespace UniformRenamer.Core
{
    using System.Text;

    interface IRule
    {
        string destinationTag
        {
            get; set;
        }

        // ref used to return two strings in one call
        void Apply(ref string oldName, ref string newFormat);
    }
}