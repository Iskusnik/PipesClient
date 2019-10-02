using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Pipes
{
    public partial class frmMain : Form
    {
        private Int32 PipeHandleSend;   // дескриптор канала

        private Int32 PipeHandleRead;   // дескриптор канала
        private string PipeName = "\\\\" + Dns.GetHostName() + "\\pipe\\ServerPipe";    // имя канала, Dns.GetHostName() - метод, возвращающий имя машины, на которой запущено приложение
        private Thread t;                                                               // поток для обслуживания канала приёма сообщений
        private bool _continue = true;                                                  // флаг, указывающий продолжается ли работа с каналом




        // конструктор формы
        public frmMain()
        {
            InitializeComponent();
            this.Text += "     " + Dns.GetHostName();   // выводим имя текущей машины в заголовок формы
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = "msg_" + tbMessage.Text + "_" + textBoxName.Text;
            SendMessage(message, tbPipe.Text);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            this.Text = "\\\\" + Dns.GetHostName() + "\\pipe\\" + textBoxName.Text;


            //Отправка сообщения для регистрации клиента
            string message = "reg_" + "\\\\" + "." + "\\pipe\\" + textBoxName.Text + "_" + textBoxName.Text;
            SendMessage(message, tbPipe.Text);


            //Создаем трубу для чтения сообщений с сервера
            PipeName = "\\\\" + "." + "\\pipe\\"+ textBoxName.Text;
            PipeHandleRead = DIS.Import.CreateNamedPipe(PipeName, DIS.Types.PIPE_ACCESS_DUPLEX | DIS.Types.OVERLAPPED, DIS.Types.PIPE_TYPE_BYTE | DIS.Types.PIPE_WAIT, DIS.Types.PIPE_UNLIMITED_INSTANCES, 0, 1024, DIS.Types.NMPWAIT_WAIT_FOREVER, (uint)0);
            
            if (t != null && t.IsAlive)
                t.Abort();

            t = new Thread(ReceiveMessage);
            t.Start();
        }

        unsafe private void ReceiveMessage()
        {
            string msg = "";            // прочитанное сообщение
            uint realBytesReaded = 0;   // количество реально прочитанных из канала байтов
            rtbMessages.Invoke((MethodInvoker)delegate
            {
                rtbMessages.Text += "\n >> подключение к " + tbPipe.Text;                           // выводим полученное сообщение на форму
            });
            
            // входим в бесконечный цикл работы с каналом
            while (_continue)
            {
                if (DIS.Import.ConnectNamedPipe(PipeHandleRead, 0))
                {
                    byte[] buff = new byte[1024];                                           // буфер прочитанных из канала байтов
                    DIS.Import.FlushFileBuffers(PipeHandleRead);                                // "принудительная" запись данных, расположенные в буфере операционной системы, в файл именованного канала
                    DIS.Import.ReadFile(PipeHandleRead, buff, 1024, ref realBytesReaded, 0);    // считываем последовательность байтов из канала в буфер buff
                    msg = Encoding.Unicode.GetString(buff);                                 // выполняем преобразование байтов в последовательность символов
                    rtbMessages.Invoke((MethodInvoker)delegate
                    {
                        if (msg != "")
                            rtbMessages.Text += "\n >> " + msg;                             // выводим полученное сообщение на форму
                    });

                    DIS.Import.DisconnectNamedPipe(PipeHandleRead);                             // отключаемся от канала сервера 
                    Thread.Sleep(500);                                                      // приостанавливаем работу потока перед тем, как приcтупить к обслуживанию очередного клиента
                }
            }
        }
        private void SendMessage(string msg, string serverPipe)
        {
            uint BytesWritten = 0;  // количество реально записанных в канал байт
            byte[] buff = Encoding.Unicode.GetBytes(msg);    // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт

            // открываем именованный канал, имя которого указано serverPipe
            Int32 PipeHandleSendMsg = DIS.Import.CreateFile(serverPipe, DIS.Types.EFileAccess.GenericWrite, DIS.Types.EFileShare.Read, 0, DIS.Types.ECreationDisposition.OpenExisting, 0, 0);
            DIS.Import.WriteFile(PipeHandleSendMsg, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);         // выполняем запись последовательности байт в канал
            DIS.Import.CloseHandle(PipeHandleSendMsg);
            Thread.Sleep(500);
        }
    }
}
