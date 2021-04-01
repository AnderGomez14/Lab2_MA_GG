using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EncriptarPasswords
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("CUIDADO: VAS A ENCRIPTAR TODAS LAS CONTRASEÑAS");
            Console.WriteLine("Esta accion no tiene vuelta atras y no diferencia entre contraseñas encriptadas y no encriptadas");
            Console.WriteLine();
            Console.Write("Pulse para continuar...");
            Console.ReadKey();


            SqlDataAdapter adapter;
            DataSet dataset;
            string sql = "Server=tcp:hads21-10.database.windows.net,1433;Initial Catalog=HADS21-10;Persist Security Info=False;User ID=garcitxiki@gmail.com@hads21-10;Password=Rumble10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection con = new SqlConnection(sql);
            adapter = new SqlDataAdapter("SELECT * FROM [Usuarios]", con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataset = new DataSet());
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                row["pass"] = Encripta((string)row["pass"]);
            }
            adapter.Update(dataset);
            dataset.AcceptChanges();
        }




        public static string Encripta(string Cadena)
        {
            byte[] Clave = Encoding.ASCII.GetBytes("Vadillo$tonks");
            byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }
    }
}
