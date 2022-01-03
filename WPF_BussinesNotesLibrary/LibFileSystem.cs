using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace WPF_BussinesNotesLibrary
{
    public class LibFileSystem
    {
        public List<string> GetAllFiles(string ParentFolderpath)
        {
            var rootDirectoryInfo = new DirectoryInfo(ParentFolderpath);
            List<string> outt = new List<string>();
            foreach (var file in rootDirectoryInfo.GetFiles())
            {
                outt.Add(file.FullName);
            }
            return outt;
        }

        public List<string> GetAllFilesInside(string ParentFolderpath, string type)
        {
            List<string> outt = new List<string>();
            if (ParentFolderpath != "")
            {
                var rootDirectoryInfo = new DirectoryInfo(ParentFolderpath);
                var files = Directory.GetFiles(ParentFolderpath, type, SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    outt.Add(file);
                }
            }
            return outt;
        }

        public List<string> GetAllDirectory(string ParentFolderpath)
        {
            var rootDirectoryInfo = new DirectoryInfo(ParentFolderpath);
            List<string> outt = new List<string>();
            foreach (var file in rootDirectoryInfo.GetDirectories())
            {
                outt.Add(file.FullName);
            }
            return outt;
        }

        public decimal GetFileSize(string ParentFolderpath)
        {

            var rootDirectoryInfo = new FileInfo(ParentFolderpath);
            return rootDirectoryInfo.Length;
        }

        public List<string> GetAllFtpFiles(string ParentFolderpath, string UserId, string Password)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ParentFolderpath);
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CompareFilesByte(string file1, string file2)
        {
            using (var fs1 = new FileStream(file1, FileMode.Open))
            using (var fs2 = new FileStream(file2, FileMode.Open))
            {
                if (fs1.Length != fs2.Length) return false;
                int b1, b2;
                do
                {
                    b1 = fs1.ReadByte();
                    b2 = fs2.ReadByte();
                    if (b1 != b2 || b1 < 0) return false;
                }
                while (b1 >= 0);
            }
            return true;
        }

        public string HashFile(string file)
        {
            using (var fs = new FileStream(file, FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                var hash = new SHA512CryptoServiceProvider();
                hash.ComputeHash(reader.ReadBytes((int)file.Length));
                return Convert.ToBase64String(hash.Hash);
            }
        }

        public bool CompareFilesWithHash(string file1, string file2)
        {
            var str1 = HashFile(file1);
            var str2 = HashFile(file2);
            return str1 == str2;
        }

        public List<string> WierszRodzielonyZnakiem(string wiersz, string znak)
        {
            List<string> lista = new List<string>();

            lista = wiersz.Split(znak).ToList();

            return lista;
        }

        public string ClearAsciiCharacters(string doCzyszczenia)
        {
            string fallbackStr = "";

            Encoding enc = Encoding.GetEncoding(Encoding.ASCII.CodePage,
              new EncoderReplacementFallback(fallbackStr),
              new DecoderReplacementFallback(fallbackStr));

            return enc.GetString(enc.GetBytes(doCzyszczenia));
        }

        public string CreateFolderToStore(string folder)
        {
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            return path + "\\" + folder + "\\";
            //return PathDirectory = folder;
        }
        public string GetDirectory(string FilePath)
        {

            return Path.GetDirectoryName(FilePath);
        }

        public void OpenWithDefaultProgram(string path)
        {
            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }
    }
}
