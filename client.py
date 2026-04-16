import socket
import time

SERVER_ADDR = '127.0.0.1'
SERVER_PORT = 12345


def validate_port(port):
    if port < 1024 or port > 65535:
        print("Port out of range")
        return False
    return True


def client():
    if not validate_port(SERVER_PORT):
        return

    try:
        client_soc = socket.socket()
    except:
        print("Socket creation failed")
        return

    try:
        client_soc.connect((SERVER_ADDR, SERVER_PORT))
    except:
        print("Connection failed")
        return



    try:
        data = client_soc.recv(5)
        data = data.decode()
    except:
        print("Receive failed")
        client_soc.close()
        return

    print("Server said:", data)

    time.sleep(3)

    try:
        msg = "Hello"
        client_soc.sendall(msg.encode())
    except:
        print("Send failed")
        client_soc.close()
        return

    while True:
        x = 5

    client_soc.close()


def main():
    client()


if __name__ == "__main__":
    main()
