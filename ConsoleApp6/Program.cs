using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConsoleApp6;

namespace ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonMethod();     
        }

        static void PersonMethod()
        {
            using(var person = new Person())
            {

            }
        }

        /// <summary>
        /// Implementación a pelo
        /// </summary>
        static void MalaImplementacion()
        {
            var connection = new SqlConnection(@"   Data Source=(localdb)\MSSQLLocalDB;
                                                    Initial Catalog=Pizzeria;
                                                    Integrated Security=True;
                                                    Connect Timeout=30;
                                                    Encrypt=False;
                                                    TrustServerCertificate=True;
                                                    ApplicationIntent=ReadWrite;
                                                    MultiSubnetFailover=False");

            //Mala implementación
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }

            //Mala implementación v2
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
            }
            finally
            {
                connection.Dispose();
                Console.WriteLine("Estado de conexion: " + connection.State);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Using no controla excepciones
        /// </summary>
        static void UsingMethod()
        {
            using (var connection = new SqlConnection(@"   Data Source=(localdb)\MSSQLLocalDB;
                                                    Initial Catalog=pepito;
                                                    Integrated Security=True;
                                                    Connect Timeout=30;
                                                    Encrypt=False;
                                                    TrustServerCertificate=True;
                                                    ApplicationIntent=ReadWrite;
                                                    MultiSubnetFailover=False"))
            {
                connection.Open();
            }
        }
    }
}
