using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeStringInHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToCurentDirectory = System.IO.Directory.GetCurrentDirectory();
            string str;
            string strCurrent = "/styles.css";
            string strReplace = "../../styles.css";
            string strAfterReplace = null;
            bool flagReplace = false;
            int counter = 0, counterReplase = 0;
            
            DirectoryInfo useDirectory = new DirectoryInfo(pathToCurentDirectory);
            try
            {
                foreach (var fil in useDirectory.GetFiles())
                {
                    str = strAfterReplace = null;
                    flagReplace = false;
                    if (fil.Extension == ".html")
                    {
                        try
                        {
                            StreamReader strRead = new StreamReader(fil.FullName, System.Text.Encoding.Default);
                            str = strRead.ReadToEnd();
                            if (str != "")
                            {
                                if (str.Contains(strCurrent))
                                {
                                    if (!str.Contains(strReplace))
                                    {
                                        strAfterReplace = str.Replace(strCurrent, strReplace);
                                        flagReplace = true;
                                        counterReplase++;
                                       
                                    }
                                }
                            }
                            strRead.Close();
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Произошла ошибка чтения: {0} \n Файл: {1}", ex.Message, fil.Name);

                        }                                       
                        if (flagReplace)
                        {
                            try
                            {
                                StreamWriter strWrite = new StreamWriter(fil.FullName, false, System.Text.Encoding.Default);
                                strWrite.WriteLine(strAfterReplace);
                                strWrite.Close();
                                Console.WriteLine("Произведена замена в файле: {0}", fil.Name);
                            }
                            catch (Exception ex) {
                                Console.WriteLine("Произошла ошибка чтения: {0} \n В файле: {1}", ex.Message, fil.Name);
                            }
                        }                        
                        counter++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла необратимая ошибка: {0}", ex.Message);
            }
            finally {
                Console.WriteLine("\nОбработано файлов: {0}", counter);
                Console.WriteLine("\nПроизведено замен: {0}", counterReplase);
            }

            Console.ReadKey();

        }
    }
}

