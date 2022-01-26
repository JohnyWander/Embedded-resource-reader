using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace dotnet_read_emb_res
{

    



    public static class read_emb_resource
    {
        static public string result_string;
        static public Stream result_stream;
        static public byte[] result_byte_array;
      //  static private readonly bool dontmindme=false;
        static public readonly int option_result_string = 1;
        static public readonly int option_result_stream = 2;
        static public readonly int option_result_byte_array = 3;
        static public readonly int option_result_all = 4;



        static private string get_resource_path(string res_name,Assembly executing_assembly)
        {
            
            string output = executing_assembly.GetManifestResourceNames().Single(str => str.EndsWith(res_name));
            return output;
        }

        static private void read_to_string(Stream result_stream1)
        {
            StreamReader reader = new StreamReader(result_stream1);
            result_string = reader.ReadToEnd();
            reader.Dispose();
            reader.Close();
            
        }

        static private void read_to_stream(Stream result_stream2)
        {
            result_stream = result_stream2;
        }

        static private void read_to_byte_array(Stream read_stream3)
        {
            byte[] buffer = new byte[16 * 1024];
            MemoryStream stre = new MemoryStream();
            int read;
            while((read = read_stream3.Read(buffer,0,buffer.Length)) > 0)
            {
                stre.Write(buffer, 0, read);
            }

            result_byte_array = stre.ToArray();
            

        }

       public static void read(string resourcename,int option)
        {
            Assembly executing_assembly = Assembly.GetEntryAssembly();
            string name_of_resource = get_resource_path(resourcename, executing_assembly);
            Stream result_stream = executing_assembly.GetManifestResourceStream(name_of_resource);

            if (option == 1)
            {
                read_to_string(result_stream);
            }
            else if(option == 2) 
            {
                read_to_stream(result_stream);            
            }
            else if(option == 3)
            {
                read_to_byte_array(result_stream);
            }
            else if(option == 4)
            {
                read_to_string(result_stream);
                read_to_stream(result_stream);
                read_to_byte_array(result_stream);//
            }
            else
            {
                throw new Exception("No such option, try to use (1,2,3,4) or option_result_* ints");
            }
            
            



        }
    }



    public static class read_emb_resource_async
    {
        static public string result_string;
        static public Stream result_stream;
        static public byte[] result_byte_array;
      //  static private readonly bool dontmindme = false;
        static public readonly int option_result_string = 1;
        static public readonly int option_result_stream = 2;
        static public readonly int option_result_byte_array = 3;
        static public readonly int option_result_all = 4;


        static async private Task<string> get_resource_path(string res_name, Assembly executing_assembly)
        {
            
           var x = await Task<string>.Run(() =>
            {
                string output = executing_assembly.GetManifestResourceNames().Single(str => str.EndsWith(res_name));
                return output;
            });

            return x;
        }


        static private async Task read_to_string(Stream result_stream1)
        {
            await Task.Run(() =>
            {
                StreamReader reader = new StreamReader(result_stream1);
                result_string = reader.ReadToEnd();
                reader.Dispose();
                reader.Close();
            });

        }

        static private async Task read_to_stream(Stream result_stream2)
        {
            await Task.Run(() =>
                {
                    result_stream = result_stream2;
                });
        }

        static private async Task read_to_byte_array(Stream read_stream3)
        {


            await Task.Run(() =>
            {


                byte[] buffer = new byte[16 * 1024];
                MemoryStream stre = new MemoryStream();
                int read;
                while ((read = read_stream3.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stre.Write(buffer, 0, read);
                }

                result_byte_array = stre.ToArray();

            });

        }




        public static async Task read(string resourcename, int option)
        {
            await Task.Run(async () =>
            {
              //  Console.WriteLine("ASYNC");

                Assembly executing_assembly = Assembly.GetEntryAssembly();
                Task<string> res_of_get_resource=get_resource_path(resourcename, executing_assembly);
               
                string name_of_resource = res_of_get_resource.Result.ToString();
                Stream result_stream = executing_assembly.GetManifestResourceStream(name_of_resource);

                if (option == 1)
                {
                   await read_to_string(result_stream);
                }
                else if (option == 2)
                {
                   await read_to_stream(result_stream);
                }
                else if (option == 3)
                {
                   await read_to_byte_array(result_stream);
                }
                else if (option == 4)
                {
                    await read_to_string(result_stream);
                    await read_to_stream(result_stream);
                    await read_to_byte_array(result_stream);//
                }
                else
                {
                    throw new Exception("No such option, try to use (1,2,3,4) or option_result_* ints");
                }



                


            });





        }




        }








 // example of using asynchronous version of the class
 /*
        class Program
        {
            static async Task Main(string[] args)
            {
            var task = read_emb_resource_async.read("grumpy_cat.jpg", read_emb_resource.option_result_string);

            Thread.Sleep(4000);
            Console.WriteLine("1");

            await task;

            Console.WriteLine(read_emb_resource_async.result_string);






           }
 
        }
 */    
    }
