namespace UniformRenamer.Core
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using UniformRenamer.Lang;

    public class FileName
    {
        string name;
        string path;
        bool isDirectory;

        //string extension;
        public FileName(string path)
        {
            this.path = path;
            this.name = Path.GetFileName(path);
            //this.extension = Path.GetExtension(path);
            isDirectory = (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public string GetExtension()
        {
            if (!isDirectory)
            {
                return Path.GetExtension(path);
            }
            else
            {
                return "";
            }
        }

        public string GetFileName()
        {
            return Path.GetFileName(path);
        }

        public string GetFilePath()
        {
            return path;
        }

        public string GetFileNameWithoutExtension()
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public string GetRenamableNamePart()
        {
            if (!isDirectory)
            {
                return Path.GetFileNameWithoutExtension(path);
            }
            else
            {
                return Path.GetFileName(path);
            }
        }

        public bool IsDirectory()
        {
            return isDirectory;
        }

        public void Rename(string newName)
        {
            string newPath = Path.Combine(Path.GetDirectoryName(path), newName);
            if (File.Exists(newPath) || Directory.Exists(newPath))
                throw new FileExistsException("\"" + newName + "\" " + Textual.ErrorFileExists);

            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
                Directory.Move(path, newPath);
            else
                File.Move(path, newPath);

            path = newPath;
            name = newName;
        }

        public void RenameKeepExtension(string newName)
        {
            string newPath = Path.Combine(Path.GetDirectoryName(path), newName);

            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
                Directory.Move(path, newPath);
            else
                File.Move(path, newPath);

            path = newPath;
            name = newName;
        }
        //TODO strange checking all folder wheno nly one cell changed
        public override string ToString()
        {
            return name;
        }

        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            return Regex.Replace(name, invalidReStr, " ");
        }
    }

    public class FileExistsException : ApplicationException
    {
        public FileExistsException()
        {
        }

        public FileExistsException(string message)
            : base(message)
        {
        }
    }
}