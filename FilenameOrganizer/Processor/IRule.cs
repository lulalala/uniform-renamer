namespace FilenameOrganizer.Processor
{
    using System.Text;

    interface IRule
    {
        string name
        {
            get; set;
        }

        // ref used to return two strings in one call
        void Apply(ref string oldName, ref string newFormat);
    }
}