import socket
import json
import struct

SERVER_ADDR = '127.0.0.1'
SERVER_PORT = 12345

def login():
        user = input("Username: ")
        pw = input("Password: ")
        return "LOGIN", {"username": user, "password": pw}

def  sign_up():
    user = input("Username: ")
    pw = input("Password: ")
    email = input("Email: ")
    return "SIGNUP", {"username": user, "password": pw, "email": email}

def get_user_input():
    print("\n--- Trivia Client ---")
    print("1. Login")
    print("2. Signup")
    print("3. Exit")
    choice = input("Select an option: ")

    if choice == "1":
        return login()

    elif choice == "2":
        return sign_up()

    return "EXIT", None

def build_request(action, data_dict):
    # Map actions to the codes your server expects
    # (Check your C++ RequestHandler to see which IDs it listens for)
    action_to_id = {"LOGIN": 100, "SIGNUP": 101}

    msg_id = action_to_id.get(action, 0)
    json_bytes = json.dumps(data_dict).encode('utf-8')

    # '>' means Big-Endian, 'B' is 1-byte, 'I' is 4-byte unsigned int
    # This matches your server's header[5] logic
    header = struct.pack('>BI', msg_id, len(json_bytes))

    return header + json_bytes

def parse_response(sock):
    # 1. Read exactly 5 bytes (1 for ID, 4 for Length)
    header = sock.recv(5)
    if len(header) < 5:
        return None, None

    # Unpack Big-Endian: 1 byte (ID) and 4 bytes (Length)
    res_id, length = struct.unpack('>BI', header)

    # 2. Read the JSON data based on the length we just got
    data_bytes = sock.recv(length)
    response_data = json.loads(data_bytes.decode('utf-8'))

    return res_id, response_data

def main():
    client_sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_sock.connect(('127.0.0.1', 12345)) # Use your server port

    while True:
        # 1. Ask user
        action, data = get_user_input()
        if action == "EXIT":
            break

        packet = build_request(action, data)
        client_sock.sendall(packet)

        # 3. Receive and Disassemble
        res_id, res_json = parse_response(client_sock)

        if res_id:
            print(f"Server Response ({res_id}): {res_json}")
            # Access status: res_json.get('status')

    client_sock.close()

if __name__ == "__main__":
    main()
