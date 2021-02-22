using System;
using DbClient;
using GmailClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace LogicaNegocio
{
    public class Logic
    {
        public byte[] Clave = Encoding.ASCII.GetBytes("Vadillo$tonks");
        public byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
        private AzureConection conection;
        private MailService service;


        public Logic(string dbstring, string emailAddress, string password)
        {
            this.conection = new AzureConection(dbstring);
            this.service = new MailService(emailAddress, password);
        }

        public Boolean login(string email, string password)
        {
            String sql = "SELECT COUNT(*) FROM usuarios WHERE pass=@pass AND email=@email AND confirmado=1";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            string encrypted_pass = Encripta(password);
            argumentos.Add(new string[2] { "@pass", encrypted_pass });

            int result = (int)conection.ExecuteScalar(sql, argumentos);

            return result == 1;
        }

        public int Register(string email, string nombre, string apellido, string rol, string pw1)
        {
            Random rnd = new Random();
            int cod = rnd.Next(0, 9999999);

            String sql = "INSERT INTO usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values (@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass)";
            List<String[]> argumentos = new List<String[]>();

            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@nombre", nombre });
            argumentos.Add(new string[2] { "@apellidos", apellido });
            argumentos.Add(new string[2] { "@numconfir", cod.ToString() });
            argumentos.Add(new string[2] { "@tipo", rol });

            string encrypted_pass = Encripta(pw1);
            argumentos.Add(new string[2] { "@pass", encrypted_pass });

            if (conection.ExecuteNonQuery(sql, argumentos) == -1)
            {
                return 1;
            }
            else
            {
                string subject = "Confirmar cuenta en <pagina sin nombre todavia>";
                string body = "Buenas, " + nombre + ".<br>Se ha registrado un usuario con este correo, para verificar el correo, entre en el siguiente enlace  <a style='color:blue' href='https://localhost:44388/confirmar.aspx?mbr=" + email + "&numconf=" + cod + "'>Verificar</a>";

                service.send(email, subject, body);
                return 0;
            }
        }

        public Boolean confirmar(string email, string cod)
        {
            String sql = "UPDATE usuarios SET confirmado=1 WHERE email=@email AND numconfir=@numconfir AND confirmado=0";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@numconfir", cod });

            int result = conection.ExecuteNonQuery(sql, argumentos);

            return result == 1;
        }

        public Boolean checkCod(string codpass)
        {
            String sql = "SELECT COUNT(*) FROM usuarios WHERE codpass=@codpass";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@codpass", codpass });
            int result = (int)conection.ExecuteScalar(sql, argumentos);
            return result == 1;

        }

        public Boolean sendResetMail(string email)
        {
            Random rnd = new Random();
            int cod = rnd.Next(0, 9999999);

            string sql = "UPDATE usuarios SET codpass=@cod WHERE email=@email";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@cod", cod.ToString() });

            if (conection.ExecuteNonQuery(sql, argumentos) != 1)
            {
                return false;
            }
            else
            {
                string subject = "Cambiar contraseña de en <pagina sin nombre todavia>";
                string body = "Buenas,<br>Se ha registrado una solicitud para resetear la contraseña, Pinche  <a style='color:blue' href='https://localhost:44388/cambiarPassword.aspx?resetcod=" + cod + "'>Aqui</a> para cambiarla.";

                service.send(email, subject, body);

                return true;
            }
        }
        public Boolean changePassword(string cod, string pass)
        {
            string sql = "UPDATE usuarios SET pass=@pass, codpass=NULL WHERE codpass=@codpass";
            List<String[]> argumentos = new List<String[]>();
            string encrypted_pass = Encripta(pass);
            argumentos.Add(new string[2] { "@pass", encrypted_pass });
            argumentos.Add(new string[2] { "@codpass", cod });
            return (conection.ExecuteNonQuery(sql, argumentos) == 1);
        }

        public string Encripta(string Cadena)
        {

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



        public string Desencripta(string Cadena)
        {
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }
    }
}
