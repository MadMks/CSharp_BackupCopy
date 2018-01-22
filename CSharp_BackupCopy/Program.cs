using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



enum DiskType
{
    eOneSide = 1,
    eTwoSides
}


namespace CSharp_BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            User user = new User();
            WorkPC workPC = new WorkPC();

            try
            {
                Menu.Start(user, workPC);
            }
            catch (DivideByZeroException e)
            {
                Design.Red();
                WriteLine("\n [err] " + e.Message);
            }
            catch (FormatException e)
            {
                Design.Red();
                WriteLine("\n [err] " + e.Message);
            }
            catch (DownloadMoreThanExistsException e)
            {
                Design.Red();
                WriteLine("\n [err] " + e.Message);
            }
            catch (Exception e)
            {
                Design.Red();
                WriteLine("\n [err] " + e.Message);
            }
            finally
            {
                Design.Default();
                WriteLine("\n >>> Завершение программы.\n");
            }
            

        }
    }
}