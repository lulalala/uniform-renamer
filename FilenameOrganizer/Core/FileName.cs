namespace UniformRenamer.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class FileName
    {
        string name;
        string path;

        //string extension;
        public FileName(string path)
        {
            this.path = path;
            this.name = Path.GetFileName(path);
            //this.extension = Path.GetExtension(path);
        }

        public string GetExtension()
        {
            return Path.GetExtension(path);
        }

        public string GetFileName()
        {
            return Path.GetFileName(path);
        }

        public string GetFileNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public void Rename(string newName)
        {
            string newPath = Path.Combine(Path.GetDirectoryName(path), newName);

            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
                Directory.Move(path, newPath);
            else
                File.Move(path, newPath);

            path = newPath;
            name = newName;
        }

        public override string ToString()
        {
            return name;
        }
    }
}