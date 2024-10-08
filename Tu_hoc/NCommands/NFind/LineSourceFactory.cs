using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFind
{
    internal class LineSourceFactory
    {
        public static ILineSource[] CreateInstance(string path, bool skipOffLlineFiles)
        {
            if (string.IsNullOrEmpty(path))
            {
                return [new ConsleLineSource()];
            }
            else
            {
                string pattern;
                int idx = path.LastIndexOf(Path.PathSeparator);
                if (idx == -1)
                {
                    pattern = path;
                    path = ".";
                   
                }
                else
                {
                    pattern = path[(idx + 1)..];
                    path = path[..idx];
                    
                }
                var dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    var files = dir.GetFiles(pattern);
                    if (skipOffLlineFiles)
                    {
                        files = files.Where(f=>f.Attributes.HasFlag(FileAttributes.Offline)).ToArray();
                    }
                    return files.Select(f=>new FileLineSource(f.FullName, f.Name)).ToArray();
                }    

            }
            return [];
        }
    }
}
