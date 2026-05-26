using System;
using System.Text;
using System.Text.Json; // Microsoft JSON library

namespace clientGraphic
{
    internal static class Serialization
    {
        /// <summary>
        /// Converts an object to JSON and builds the packet:
        /// [1 Byte Opcode] + [4 Bytes Length] + [JSON Data]
        /// </summary>
        public static byte[] BuildBuffer(byte opcode, object requestObj)
        {
            // 1. Convert the C# object into a JSON string
            string jsonString = JsonSerializer.Serialize(requestObj);

            // 2. Convert the JSON string into bytes
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
            int jsonLength = jsonBytes.Length;

            // 3. Create the full buffer array
            byte[] buffer = new byte[1 + 4 + jsonLength];

            // Byte 0: Opcode
            buffer[0] = opcode;

            // Bytes 1-4: Convert the length (int) to 4 bytes
            byte[] lengthBytes = BitConverter.GetBytes(jsonLength);

            // Network Byte Order is Big Endian, so we reverse if needed
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthBytes);
            }

            // Copy the 4 length bytes into the main buffer starting at index 1
            Array.Copy(lengthBytes, 0, buffer, 1, 4);

            // Copy the JSON bytes into the main buffer starting at index 5
            Array.Copy(jsonBytes, 0, buffer, 5, jsonLength);

            return buffer;
        }

        /// <summary>
        /// Use this when you only need to send an Opcode with 0 length (No JSON)
        /// </summary>
        public static byte[] BuildBuffer(byte opcode)
        {
            byte[] buffer = new byte[5];
            buffer[0] = opcode;
            // Bytes 1-4 will stay 0 (Length = 0)
            return buffer;
        }
    }
}