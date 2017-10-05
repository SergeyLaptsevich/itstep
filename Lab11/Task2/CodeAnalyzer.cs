using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAnalyzer
{
    public class CodeAnalyzer
    {
        public String FileName { get; private set; }
        public CodeAnalyzer(String fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName + " не найден");
            FileName = fileName;
        }

        private void WriteFile(String outFileName, String source)
        {
            using (StreamWriter sw = new StreamWriter(outFileName, false))
                sw.Write(source);
        }

        private String ReadFile(String fileName)
        {
            String source;
            using (StreamReader sr = new StreamReader(fileName))
                source = sr.ReadToEnd();

            return source;
        }

        public void ToPrivate(String outFileName)
        {
            String source = ReadFile(FileName);

            source = Regex.Replace(source, @"public(\s+(static\s+|readonly\s+)?\w+\s+(_?[a-z]))", "private$1");
            WriteFile(outFileName, source);
        }

        public void ToUpper(String outFileName)
        {
            String source = ReadFile(FileName);

            source = Regex.Replace(source, @"[a-z]{3,}", m => m.ToString().ToUpper(), RegexOptions.IgnoreCase);
            WriteFile(outFileName, source);
        }

        public void Normalize(String outFileName)
        {
            String source = ReadFile(FileName);

            source = Regex.Replace(source, @" +", " ");
            source = Regex.Replace(source, @"\t+", "");
            WriteFile(outFileName, source);
        }

        private String ReverseLine(String line)
        {
            StringBuilder result = new StringBuilder();
            for (int i = line.Length - 1; i >= 0; i--)
                result.Append(line[i]);

            result.Append("\r\n");
            return result.ToString();
        }

        public void Reverse(String outFileName)
        {
            String source = ReadFile(FileName);

            source = Regex.Replace(source, ".+\r\n", m => ReverseLine(m.ToString().Replace("\r\n", "")));

            WriteFile(outFileName, source);
        }
    }
}
