using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Shared
{
    public class FileOutput : OutputStream
    {
        private string Filename { get; set; }
        private FileStream FileStream { get; set; }
        private StreamWriter Writer { get; set; }

        public FileOutput(string filename)
        {
            Filename = filename;
        }

        public override void Dispose()
        {
            if (FileStream != null)
            {
                Writer.Flush();
                FileStream.Flush();
                Writer.Close();
                FileStream.Close();
                Writer.Dispose();
                FileStream.Dispose();
            }
        }

        public override OutputStream Open()
        {
            FileStream = File.Create(Filename);
            Writer = new StreamWriter(FileStream);
            return this;
        }

        public override void Write(string s)
        {
            Writer.Write(s);
        }

        public override void Write(char c)
        {
            Writer.Write(c);
        }

        public override void WriteNewLine()
        {
            Writer.WriteLine();
        }

        public override void Write(int i)
        {
            Writer.Write(i);
        }
    }
}
