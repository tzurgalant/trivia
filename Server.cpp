#include "Server.h"
#include <thread>
#include <iostream>
#include <string>


Server::Server():m_communicator(Communicator())
{

}
Server::~Server()
{
    shutdown();
}
void Server::run()
{
    std::cout << "Server is starting to run..." << std::endl;

    try {
        std::thread acceptThread(&Communicator::startHandleRequest, &m_communicator);
        acceptThread.detach();
    }
    catch (const std::exception& e) {
        std::cerr << "Critical error in Server run: " << e.what() << std::endl;
    }
    
}

void Server::shutdown()
{
    m_communicator.closeAllClients();
}
