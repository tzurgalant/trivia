#pragma once

#include <WinSock2.h>
#include <Windows.h>
#include <queue>
#include <exception>
#include <map>
#include "mutex"
#include "Communicator.h"
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include <iostream>
#define PORT 12345

class Communicator
{
public:
	Communicator() = default;
	Communicator(RequestHandlerFactory& handleFactory);
	~Communicator();



	void startHandleRequest();
	void closeAllClients();
private:

	RequestHandlerFactory& m_handleFactory;
	SOCKET m_serverSocket;
	std::map <SOCKET, IRequestHandler *> m_clients;// map whhaty the handler now for the client
	void bindAndLsiten() const;
	void handleNewClient(SOCKET userS);
	void closeClient(SOCKET userS);
};

