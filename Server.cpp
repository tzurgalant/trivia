#include "Server.h"
#include <thread>
#include <iostream>
#include <string>


Server::Server():m_database(new SqliteDatabase()), m_handleFactory(m_database),m_communicator(m_handleFactory)
{
    if (!m_database->open())
    {
        std::cerr << "Error: Could not open database file!" << std::endl;
    }
    else
    {
        std::cout << "Database opened successfully." << std::endl;
    }
}

Server::~Server()
{
    shutdown();
    delete m_database;
    m_database = nullptr;
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
