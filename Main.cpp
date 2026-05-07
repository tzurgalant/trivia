#pragma comment (lib, "ws2_32.lib")
#include "Communicator.h"
#include "Server.h"
#include <iostream>

int main()
{
    WSAData wsaData;// need to init windoes for use sinSock
    if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {
        return 1;
    }
    Server server;

    server.run();
    std::string input;
    while (true)
    {
        std::cin >> input;

        if (input == "EXIT")
        {
            std::cout << "Exit command received. Closing all connections..." << std::endl;

            server.shutdown();

            break;
        }
        else if(input == "hello")
        {

        }
        else
        {
            std::cout << "Unknown command: " << input << std::endl;
        }
    }
}



