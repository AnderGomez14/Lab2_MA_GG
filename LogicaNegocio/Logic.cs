using DbClient;
using GmailClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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

        public int login(string email, string password)
        {
            return conection.login(email, password);
        }

        public int Register(string email, string nombre, string apellido, string rol, string pw1)
        {
            int cod = conection.Register(email, nombre, apellido, rol, pw1);
            if (cod == -1)
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
            return conection.confirmar(email, cod);
        }

        public Boolean checkCod(string codpass)
        {
            return conection.checkCod(codpass);
        }

        public Boolean sendResetMail(string email)
        {
            int cod = conection.sendResetMail(email);
            if (cod == -1)
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
            return conection.changePassword(cod, pass);
        }

        public DataTable getAsignaturas(string email)
        {
            return conection.getAsignaturas(email);
        }

        public DataTable getTareasFromAsignatura(string email, string codAsig)
        {
            return conection.getTareasFromAsignatura(email, codAsig);
        }

        public Boolean checkCodTareaInstanciar(string email, string cod)
        {
            return conection.checkCodTareaInstanciar(email, cod);
        }

        public DataTable getTareasInstanciadasFromEmail(string email)
        {
            return conection.getTareasInstanciadasFromEmail(email);
        }

        public int getHoursofTareaGenerica(string tarea)
        {
            return conection.getHoursofTareaGenerica(tarea);
        }
        public int instanciarTareaGenerica(string email, string cod, string tiempoDedicado)
        {
            return conection.instanciarTareaGenerica(email, cod, tiempoDedicado);
        }

        public SqlConnection getConnection()
        {
            return conection.getConnection();
        }

        public int crearTarea(Dictionary<string, object> argumentos)
        {
            return conection.crearTarea(argumentos);
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
