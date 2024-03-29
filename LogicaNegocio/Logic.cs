﻿using DbClient;
using GmailClient;
using LogicaNegocio.PasswordService;
using LogicaNegocio.serviciocalcularmedia;
using LogicaNegocio.ServicioMatriculas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

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
            return conection.login(email, Encripta(password));
        }

        public int Register(string email, string nombre, string apellido, string rol, string pw1, string entorno)
        {
            if (!comprobarMatricula(email))
                return 2;
            if (!comprobarPass(pw1))
                return 3;
            int cod = conection.Register(email, nombre, apellido, rol, Encripta(pw1));
            if (cod == -1)
            {
                return 1;
            }
            else
            {
                string subject = "Confirmar cuenta en <pagina sin nombre todavia>";
                string body = "Buenas, " + nombre + ".<br>Se ha registrado un usuario con este correo, para verificar el correo, entre en el siguiente enlace  <a style='color:blue' href='" + entorno + "confirmar.aspx?mbr=" + email + "&numconf=" + cod + "'>Verificar</a>";

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

        public Boolean sendResetMail(string email, string entorno)
        {
            int cod = conection.sendResetMail(email);
            if (cod == -1)
            {
                return false;
            }
            else
            {
                string subject = "Cambiar contraseña de en <pagina sin nombre todavia>";
                string body = "Buenas,<br>Se ha registrado una solicitud para resetear la contraseña, Pinche  <a style='color:blue' href='" + entorno + "cambiarPassword.aspx?resetcod=" + cod + "'>Aqui</a> para cambiarla.";

                service.send(email, subject, body);

                return true;
            }
        }

        public Boolean changePassword(string cod, string pass)
        {
            return conection.changePassword(cod, Encripta(pass));
        }
        /*
        public DataTable getAsignaturas(string email)
        {
            return conection.getAsignaturas(email);
        }

        public DataTable getTareasFromAsignatura(string email, string codAsig)
        {
            return conection.getTareasFromAsignatura(email, codAsig);
        }
        */
        public Boolean checkCodTareaInstanciar(string email, string cod)
        {
            return conection.checkCodTareaInstanciar(email, cod);
        }
        /*
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
        */
        public SqlConnection getConnection()
        {
            return conection.getConnection();
        }

        public int crearTarea(Dictionary<string, object> argumentos)
        {
            return conection.crearTarea(argumentos);
        }

        public int insertarTareas(XmlDocument xml, string CodAsig)
        {
            return conection.insertarTareas(xml, CodAsig);
        }

        public DataView getDataViewFromCodasig(string CodAsig)
        {
            return conection.getDataViewFromCodasig(CodAsig);
        }

        public string exportarXML(string CodAsig, string path)
        {
            return conection.exportarXML(CodAsig, path);
        }

        public string exportarJSON(string CodAsig, string path)
        {
            return conection.exportarJSON(CodAsig, path);
        }
        public int insertarTareasJSON(string json, string codAsig)
        {
            return conection.insertarTareasJSON(json, codAsig);
        }
        public int insertarTareasDataset(string pathxml, string codAsig)
        {
            return conection.insertarTareasDataset(pathxml, codAsig);
        }

        public double calcularMedia(string codAsig)
        {
            ServicioWebMedias cliente = new ServicioWebMedias();
            return cliente.DedicacionMedia(codAsig);
        }

        public bool comprobarMatricula(string email)
        {
            Matriculas mat = new Matriculas();
            if (mat.comprobar(email) == "NO")
                return false;
            else return true;
        }

        public bool comprobarPass(string pass)
        {
            Service1Client client = new Service1Client();
            bool tellesita = client.Comprobar(pass, "tenia_que_haber_satelites");
            client.Close();
            return tellesita;
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
