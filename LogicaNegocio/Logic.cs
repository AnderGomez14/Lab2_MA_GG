using System;
using DbClient;
using GmailClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Logic
    {
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
            argumentos.Add(new string[2] { "@pass", password });

            int result = (int)conection.ExecuteScalar(sql, argumentos);

            return result == 1 ? true : false;
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
            argumentos.Add(new string[2] { "@pass", pw1 });

            if (conection.ExecuteNonQuery(sql, argumentos) == -1)
            {
                conection.close();
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

        public Boolean confirmar(string email, string cod )
        {
            String sql = "UPDATE usuarios SET confirmado=1 WHERE email=@email AND numconfir=@numconfir AND confirmado=0";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@numconfir", cod });

            int result = conection.ExecuteNonQuery(sql, argumentos);

            return result == 1 ? true : false;
        }

        public Boolean checkCod(string codpass)
        {
            String sql = "SELECT COUNT(*) FROM usuarios WHERE codpass=@codpass";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@codpass", codpass });
            int result = (int)conection.ExecuteScalar(sql, argumentos);
            return result == 1 ? true : false;

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
            argumentos.Add(new string[2] { "@pass", pass });
            argumentos.Add(new string[2] { "@codpass", cod });
            return (conection.ExecuteNonQuery(sql, argumentos) == 1);
        }
    }
}
