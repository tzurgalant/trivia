import socket

SERVER_ADDR = '127.0.0.1'

def server(listening_sock):
    try:
        client_soc, client_address = listening_sock.accept()
        with client_soc:
            print(f"Client connected: {client_address}")

            try:
                data = client_soc.recv(5)
                data = data.decode()
            except:
                print("Read error")
                return

            print("Received:", data)

            if data == "Hello":
                try:
                    client_soc.sendall("Hello".encode())
                except:
                    print("Write error")

    except ConnectionResetError as error:
        print(error)


def main():
    port = int(input("enter port: "))

    if port < 1024 or port > 65535:
        print("Port out of range")
        return

    with socket.socket() as listening_sock:
        try:
            listening_sock.bind((SERVER_ADDR, port))
            listening_sock.listen(1)
        except:
            print("Bind/Listen failed")
            return

        print("Server is listening...")

        while True:
            server(listening_sock)


if __name__ == '__main__':
    main()
