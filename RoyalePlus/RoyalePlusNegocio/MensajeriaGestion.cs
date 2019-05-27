using RoyalePlusDatos.BD;
using RoyalePlusDatos.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Globalization;
using System.Net.Http;
using System.Web;

namespace RoyalePlusNegocio
{
    public class MensajeriaGestion
    {
        public List<Chat> obtenerTodosChatsDeUnJugador(Usuario usuario)
        {
            // Insercion
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                   var datos = ctx.PA_OBTENER_TODOS_CHATS_DE_UN_USUARIO6(usuario.idUsuario.ToString(), paramRETCODE, paramMENSAJE).ToList();
                    List<Chat> chats = new List<Chat>();
                    Chat chat;

                    foreach (PA_OBTENER_CHATS s in datos)
                    {
                        chat = new Chat
                        {
                            idChat = s.ID_CHAT,
                            ultimoMensaje = s.ULTIMO_MENSAJE,
                            ultimoTiempo = s.ULTIMO_TIEMPO ?? new DateTime(),
                            ultimoEnHablar = s.ULTIMO_EN_HABLAR,
                            nombreChat = s.NOMBRE_CHAT,
                            tipoChat = s.TIPO,
                            mensajesSinLeer = s.MENSAJES_SIN_LEER ?? 0,
                            idContrario = s.ID_CONTRARIO ?? 0
                        };
                        obtenerImagen(chat);
                        chats.Add(chat);
                    }

                    return chats;
                }
            }
            catch (Exception ex)
            {
                return new List<Chat>();
            }
        }

        private void obtenerImagen(Chat chat)
        {
            //String id = "0";
            //String tipo = "user-";
            //if(chat.tipoChat == "PRIVADO" || chat.tipoChat == "ADMIN")
            //{
            //    id = chat.idContrario.ToString();
            //}
            //else
            //{
            //    id = chat.idChat.ToString();
            //    tipo = "group-";
            //}
            //Byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("/App_Data/" + tipo + id));
            //chat.imagen = Convert.ToBase64String(bytes);

            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("/App_Data"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var file in fileInfo)
            {
                string nombre = file.Name;
                var nombreArray = nombre.Split('-');
                if (chat.tipoChat == "PRIVADO" || chat.tipoChat == "ADMIN")
                {
                    if (nombreArray[0] == "user")
                    {
                        var id = nombreArray[1].Split('.')[0];
                        var extension = nombreArray[1].Split('.')[1];
                        if (chat.idContrario == Int32.Parse(id))
                        {
                            Byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("/App_Data/" + nombre));
                            chat.imagen = Convert.ToBase64String(bytes);
                            chat.tipoImagen = extension;
                        }
                    }
                }
                else
                {
                    if (nombreArray[0] == "group")
                    {
                        var id = nombreArray[1].Split('.')[0];
                        if (chat.idChat == Int32.Parse(id))
                        {
                            Byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("/App_Data/" + nombre));
                            chat.imagen = Convert.ToBase64String(bytes);
                        }
                    }
                }
            }
        }

        public Usuario obtenerInfoUsuario(Usuario usuario)
        {
            using (var ctx = new ROYALEPLUSEntities())
            {
                var datos = ctx.USUARIOS.Select(s => new Usuario
                {
                    idUsuario = s.ID_USUARIO,
                    nombre = s.NOMBRE,
                    contrasena = s.CONTRASENA,
                    tipo = s.TIPO,
                    activo = s.ACTIVO ?? false
                }).Where(x => x.nombre == usuario.nombre);

                var resultado = datos.ToList();

                return resultado[0];
            }
        }

        public List<Mensaje> obtener100MensajesDeUnChat(Chat chat)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    var datos = ctx.PA_OBTENER_100_MENSAJES_DE_UN_CHAT1(0, chat.idChat, paramRETCODE, paramMENSAJE).ToList();
                    List<Mensaje> mensajes = new List<Mensaje>();
                    Mensaje mensaje;

                    foreach (PA_OBTENER_100_MENSAJES s in datos)
                    {
                        mensaje = new Mensaje
                        {
                            idMensaje = s.ID_MENSAJE,
                            idChat = s.ID_CHAT,
                            idUsuario = s.ID_USUARIO,
                            nombreUsuario = s.NOMBRE_USUARIO,
                            tiempo = s.TIEMPO,
                            leido = s.LEIDO,
                            mensaje = s.MENSAJE
                        };
                        mensajes.Add(mensaje);
                    }

                    return mensajes;
                }
            }
            catch (Exception ex)
            {
                return new List<Mensaje>();
            }
        }

        public RespuestaGenerica enviarMensaje(Mensaje mensaje)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    ctx.PA_INSERTAR_MENSAJE(mensaje.idChat, mensaje.idUsuario, mensaje.mensaje, paramRETCODE, paramMENSAJE);

                    if ((int)paramRETCODE.Value > 0)
                    {
                        return new RespuestaGenerica()
                        {
                            RetCode = (int)paramRETCODE.Value,
                            Mensaje = paramMENSAJE.Value.ToString()
                        };
                    }

                    if ((int)paramRETCODE.Value < 0)
                    {
                        throw new Exception(paramMENSAJE.Value.ToString());
                    }


                    return new RespuestaGenerica();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Mensaje> obtenerMensajesNuevos(Mensaje mensaje)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    var datos = ctx.PA_OBTENER_MENSAJES_NUEVOS1(mensaje.idChat, mensaje.idMensaje, paramRETCODE, paramMENSAJE);
                    List<Mensaje> mensajes = new List<Mensaje>();
                    Mensaje m;

                    foreach (PA_OBTENER_100_MENSAJES s in datos)
                    {
                        m = new Mensaje
                        {
                            idMensaje = s.ID_MENSAJE,
                            idChat = s.ID_CHAT,
                            idUsuario = s.ID_USUARIO,
                            nombreUsuario = s.NOMBRE_USUARIO,
                            tiempo = s.TIEMPO,
                            leido = s.LEIDO,
                            mensaje = s.MENSAJE
                        };
                        mensajes.Add(m);
                    }

                    return mensajes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RespuestaGenerica marcarComoLeidoTodo(Chat chat)
        {
            try
            {
                using (var ctx = new ROYALEPLUSEntities())
                {
                    ObjectParameter paramMENSAJE = new ObjectParameter("MENSAJE", typeof(string));
                    ObjectParameter paramRETCODE = new ObjectParameter("RETCODE", typeof(int));

                    ctx.PA_MARCAR_TODOS_COMO_LEIDOS(chat.idChat, chat.idUsuario, paramRETCODE, paramMENSAJE);

                    if ((int)paramRETCODE.Value > 0)
                    {
                        return new RespuestaGenerica()
                        {
                            RetCode = (int)paramRETCODE.Value,
                            Mensaje = paramMENSAJE.Value.ToString()
                        };
                    }

                    if ((int)paramRETCODE.Value < 0)
                    {
                        throw new Exception(paramMENSAJE.Value.ToString());
                    }


                    return new RespuestaGenerica();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
