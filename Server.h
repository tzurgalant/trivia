#pragma once


#include <WinSock2.h>
#include <Windows.h>
#include "mutex"
#include <queue>
#include <exception>
#include "Communicator.h"

class Server
{
public:
	Server();
	~Server();
	void run();
	void shutdown();
private:
	Communicator m_communicator; 
};


