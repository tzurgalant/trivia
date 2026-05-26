using System;
using System.Text;
using System.Text.Json; // Microsoft JSON library

namespace clientGraphic
{
    internal static class Deserialization
    {
        /// <summary>
        /// Reads the first 5 bytes from the server's response to get the Opcode and JSON Length.
        /// Header format: [1 Byte Opcode] + [4 Bytes Length]
        /// </summary>
        public static void ParseHeader(byte[] headerBuffer, out byte opcode, out int jsonLength)
        {
            // Byte 0 is always the Opcode
            opcode = headerBuffer[0];

            // Bytes 1-4 are the length of the JSON string
            byte[] lengthBytes = new byte[4];
            Array.Copy(headerBuffer, 1, lengthBytes, 0, 4);

            // Network Byte Order is Big Endian, so we reverse if needed
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }

            // Convert the 4 bytes back to an integer
            jsonLength = BitConverter.ToInt32(lengthBytes, 0);
        }

        /// <summary>
        /// Converts the raw JSON bytes received from the server into a C# object.
        /// </summary>
        public static T DeserializeResponse<T>(byte[] jsonBytes)
        {
            try
            {
                // 1. Convert the bytes into a UTF8 string
                string jsonString = Encoding.UTF8.GetString(jsonBytes);

                // 2. Convert the JSON string into the requested C# object type (T)
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing data: {ex.Message}");
                return default(T); // Returns null for classes, or default values for structs
            }
        }
    }
}