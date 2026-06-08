using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace clientGraphic
{
    internal static class Communicator
    {
        private static TcpClient _client;
        private static NetworkStream _stream;

        public static bool Connect(string ip, int port)
        {
            try
            {
                _client = new TcpClient(ip, port);
                _stream = _client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not connect to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //the same fucnkton but for request taht not habe a data on thiat requests
        public static TResponse SendAndReceive<TResponse>(byte opcode)
        {
           
            return SendAndReceive<TResponse>(opcode, null);
        }
        public static TResponse SendAndReceive<TResponse>(byte opcode, object requestObj)
        {
            try
            {
                //send msg to the server
                byte[] sendBuffer = Serialization.BuildBuffer(opcode, requestObj);
                _stream.Write(sendBuffer, 0, sendBuffer.Length);
                _stream.Flush();

                //recive msg from the server
                byte[] headerBuffer = new byte[5];

                for (int i = 0; i < 5; i++)
                {
                    if(_stream.Read(headerBuffer, i, 1) == 0) //read 5 bites (the header of the msg) to the buffer
                    {
                        throw new Exception("server response is too short");
                    }
                }
                
                byte responseOpcode;
                int jsonLength;
                Deserialization.ParseHeader(headerBuffer, out responseOpcode, out jsonLength);

                byte[] jsonBuffer = new byte[jsonLength];
                for (int i = 0; i < jsonLength; i++)
                {
                    if (_stream.Read(jsonBuffer, i, 1) == 0) //read 5 bites (the header of the msg) to the buffer
                    {
                        throw new Exception("server response is too short");
                    }
                }
                if (headerBuffer[0] == (byte)CodeR.ErrorCmd)
                {
                    Deserialization.DeserializeResponse<TResponse>(jsonBuffer);
                    return default(TResponse);
                }
                return Deserialization.DeserializeResponse<TResponse>(jsonBuffer);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Communication error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(TResponse);
            }
        }
    }
}