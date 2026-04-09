#pragma once

#include <WinSock2.h>
#include <Windows.h>
#include <queue>
#include <exception>
#include <map>
#include "mutex"
#include "Communicator.h"
#include "IRequestHandler.h"
#include <iostream>
#define PORT 12345

class Communicator
{
public:
	Communicator();
	~Communicator();



	void startHandleRequest();
	void closeAllClients();
private:
	void bindAndLsiten() const ;
	void handleNewClient(SOCKET userS);
	void closeClient(SOCKET userS);

	SOCKET m_serverSocket;
	std::map <SOCKET, IRequestHandler *> m_clients;
};

