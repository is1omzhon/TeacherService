using System;
using System.IO;

namespace TeacherService.Utils
{
    public static class TreeViewer
    {
        public static void ShowDirectoryTree(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine($" Directory not found: {path}");
                    return;
                }

                Console.WriteLine($" {Path.GetFileName(path)}");
                ShowDirectoryTreeRecursive(path, "");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($" Access denied to: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private static void ShowDirectoryTreeRecursive(string path, string indent)
        {
            try
            {
                // Papkalarni chiqarish
                foreach (var dir in Directory.GetDirectories(path))
                {
                    Console.WriteLine($"{indent}├──  {Path.GetFileName(dir)}");
                    ShowDirectoryTreeRecursive(dir, indent + "│   ");
                }

                // Fayllarni chiqarish
                foreach (var file in Directory.GetFiles(path))
                {
                    var fileInfo = new FileInfo(file);
                    Console.WriteLine($"{indent}├──  {Path.GetFileName(file)} ({fileInfo.Length} bayt)");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"{indent}├──  Access denied");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{indent}├──  Error: {ex.Message}");
            }
        }

        public static void ShowDetailedTree(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine($"❌ Directory not found: {path}");
                    return;
                }

                var dirInfo = new DirectoryInfo(path);
                Console.WriteLine($"{dirInfo.FullName}");
                Console.WriteLine($" Created: {dirInfo.CreationTime:dd.MM.yyyy HH:mm}");
                Console.WriteLine($" Modified: {dirInfo.LastWriteTime:dd.MM.yyyy HH:mm}");
                Console.WriteLine(new string('─', 40));

                ShowDetailedTreeRecursive(path, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        private static void ShowDetailedTreeRecursive(string path, string indent)
        {
            try
            {
                // Papkalar
                var dirs = Directory.GetDirectories(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    var dir = dirs[i];
                    bool isLast = (i == dirs.Length - 1 && Directory.GetFiles(path).Length == 0);
                    string prefix = isLast ? "└── " : "├── ";

                    var dirInfo = new DirectoryInfo(dir);
                    Console.WriteLine($"{indent}{prefix} {Path.GetFileName(dir)} ({dirInfo.CreationTime:dd.MM.yyyy})");

                    string newIndent = indent + (isLast ? "    " : "│   ");
                    ShowDetailedTreeRecursive(dir, newIndent);
                }

                // Fayllar
                var files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                {
                    var file = files[i];
                    bool isLast = (i == files.Length - 1);
                    string prefix = isLast ? "└── " : "├── ";

                    var fileInfo = new FileInfo(file);
                    Console.WriteLine($"{indent}{prefix} {Path.GetFileName(file)} ({fileInfo.Length} bayt)");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"{indent}├──  Access denied");
            }
        }
    }
}