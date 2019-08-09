using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AdventOfCode2018
{
    public class FileInput : InputStream
    {
        private string Filename { get; set; }

        public FileInput(string filename)
        {
            Filename = filename;
        }

        public override IEnumerator<string> GetEnumerator()
        {
            return File.ReadAllLines(Filename).ToList().GetEnumerator();
        }
    }
}
