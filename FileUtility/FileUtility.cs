using System;
using System.IO;
using System.Reflection;

namespace codeprompt.github.io
{

    /* MAP of "FileUtility"

    FileUtility.DeleteFile(string)            ->bool                    fullPath
    FileUtility.FileExists(string)            ->bool                    fullPath
    FileUtility.AppFileName()                 ->string

    FileUtility.BuildPath(object[])           ->string                  pathItems
    FileUtility.GetFileName(string)           ->string                  fullPath
    FileUtility.GetPath(string)               ->string                  fullPath
    FileUtility.GetFileNameBase(string)       ->string                  fullPath
    FileUtility.GetExtension(string)          ->string                  fileName

    */
    public class FileUtility
    {
        /// <summary>
        /// Try to delete a file, but continue should an error occur.
        /// </summary>
        /// <param name="fullPath">The file path.</param>
        /// <returns></returns>
        public static bool DeleteFile(string fullPath)
        {
            try
            {
                if (!FileExists(fullPath)) return false;
                File.Delete(fullPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Wether a file exists.
        /// </summary>
        /// <param name="fullPath">The file path.</param>
        /// <returns>True if file exists, or false if not.</returns>
        public static bool FileExists(string fullPath)
        {
            return File.Exists(fullPath);
        }

        /// <summary>
        /// Get the folder path to the current App exe.
        /// </summary>
        /// <returns>The folder path to the current exe.</returns>
        public static string AppPath()
        {
            string result;
            try
            {
                string location = Assembly.GetExecutingAssembly().Location;
                result = GetPath(location);
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        } 



        /// <summary>
        /// Build path from folder names provided in an array.
        /// </summary>
        /// <param name="pathItems">The array of folder names as strings.</param>
        /// <returns>The desired path.</returns>
        public static string BuildPath(params object[] pathItems)
        {
            string path = "";

            for (int i = 0; i < pathItems.Length; i++)
            {
                if (pathItems[i] is string)
                {
                    string text2 = Convert.ToString(pathItems[i]);

                    if (path != "" && !path.EndsWith("\\") && !text2.StartsWith("\\"))
                    {
                        path = path + "\\" + text2;
                    }
                    else
                    {
                        path += text2;
                    }
                }
            }

            return path;
        }

        /// <summary>
        /// Get file name from path.
        /// </summary>
        /// <param name="fullPath">The path.</param>
        /// <returns>The file Name.</returns>
        public static string GetFileName(string fullPath)
        {
            int index = fullPath.LastIndexOf("\\");

            string result;
            if (index == -1)
            {
                result = fullPath;
            }
            else
            {
                if (index == fullPath.Length - 1)
                {
                    result = "";
                }
                else
                {
                    result = fullPath.Substring(index + 1);
                }
            }
            return result;
        }

        /// <summary>
        /// Get folder path from file path.
        /// </summary>
        /// <param name="fullPath">The file path.</param>
        /// <returns>The name of the file.</returns>
        public static string GetPath(string fullPath)
        {
            int index = fullPath.LastIndexOf("\\");

            string result;
            if (index == -1) result = "";
            else result = fullPath.Substring(0, index);
            return result;
        }

        /// <summary>
        /// Get file name without extention.
        /// </summary>
        /// <param name="filePath">The path.</param>
        /// <returns>The file name without the extention.</returns>
        public static string GetFileNameBase(string filePath)
        {
            string fileName = GetFileName(filePath);
            int index = fileName.LastIndexOf(".");

            string result;
            if (index == -1)
            {
                result = fileName;
            }
            else
            {
                if (index == 0)
                {
                    result = "";
                }
                else
                {
                    result = fileName.Substring(0, index);
                }
            }
            return result;
        }

        /// <summary>
        /// Get extention from a filename.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        /// <returns>The extention.</returns>
        public static string GetExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".");

            string result;
            if (index == -1 || fileName.EndsWith("."))
            {
                result = "";
            }
            else
            {
                result = fileName.Substring(index + 1);
            }
            return result;
        }
    }
}