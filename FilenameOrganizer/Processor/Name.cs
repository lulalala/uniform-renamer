using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FilenameOrganizer.Processor
{
    class FileName
    {
        string path;
        string name;
        public FileName(string path)
        {
            this.path = path;
            this.name = Path.GetFileNameWithoutExtension(path);
        }
        public void Rename(string newName)
        {
            string newPath = Path.Combine(Path.GetDirectoryName(path), newName);
            try
            {
                File.Move(path, newPath);
                path = newPath;
                name = newName;
            }
            catch
            {
            }
        }
        public string GetExtension()
        {
            return Path.GetExtension(path);
        }
        public string GetFileNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        public string GetFileName()
        {
            return Path.GetFileName(path);
        }
        public override string ToString()
        {
            return name;
        }
    }
}
