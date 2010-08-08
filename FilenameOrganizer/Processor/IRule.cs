namespace FilenameOrganizer.Processor
{
    using System.Text;

    interface IRule
    {
        string name
        {
            get; set;
        }

        void Apply(StringBuilder filename, StringBuilder format);
    }
}